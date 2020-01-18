using Common.Helpers;
using Common.Extensions;
using HtmlAgilityPack;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;

namespace Services
{
    public class TibiaParser
    {
        private IWebDriver webDriver;

        public TibiaParser()
        {
            webDriver = WebDriverHelper.SetupWebDriver();
        }

        public TibiaCharacter GetTibiaCharacter(string charName)
        {
            string url = UrlHelper.FormatTibiaCharacterUrl(charName);

            TibiaCharacter tibiaCharacter = GetTibiaCharacterFromWeb(url, charName);

            return tibiaCharacter;
        }

        private TibiaCharacter GetTibiaCharacterFromWeb(string url, string charName)
        {
            // Visiting website in order to get Character information.
            webDriver.Navigate().GoToUrl(url);
            var boxContentElement = webDriver.FindElement(By.ClassName("BoxContent"));
            string characterInfoText = boxContentElement.Text;
            
            string[] characterTable = characterInfoText.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);

            //If we can't find the tibia character we search for we want to end the call.
            if(characterTable.Any(row => row.Contains("Could not find character")))
            {
                return null;
            }

            // Parsing text into easily workable data structure.
            var characterInfo = characterTable
                .Where(line => line.Contains(':'))
                .Select(line => line.Split(':')
                    .Select(lineValue => lineValue.Trim())
                );

            //Mapping information gotten from website to TibiaCharacter object.
            TibiaCharacter tibiaCharacter = MapCharacterInfoToTibiaCharacter(characterInfo,charName);

            return tibiaCharacter;
        }

        private TibiaCharacter MapCharacterInfoToTibiaCharacter(IEnumerable<IEnumerable<string>> characterInfo, string characterName)
        {
            TibiaCharacter tibiaCharacter = new TibiaCharacter();
            tibiaCharacter.Name = characterName;

            foreach (var row in characterInfo)
            {
                string title = row.ElementAt(0);
                string value = row.ElementAt(1);

                switch (title)
                {
                    case "Vocation":
                        Ensure.NotNullOrWhiteSpace(value);

                        string[] promotedVocation = value.Split(' ');
                        if (promotedVocation.Length == 2)
                        {
                            tibiaCharacter.Vocation = promotedVocation[1];
                        }
                        else
                        {
                            tibiaCharacter.Vocation = value;
                        }
                        break;
                    case "Level":
                        Ensure.NotNullOrWhiteSpace(value);
                        tibiaCharacter.Level = Int32.Parse(value);
                        break;
                    case "World":
                        Ensure.NotNullOrWhiteSpace(value);
                        tibiaCharacter.World = value;
                        break;
                    case "Guild Membership":
                        Ensure.NotNullOrWhiteSpace(value);
                        tibiaCharacter.Guild = value;
                        break;
                }
            }

            return tibiaCharacter;
        }
    }
}
