using Common.Helpers;
using Common.Extensions;
using Models;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;
using Functional.Option;
using Models.DTOs;

namespace Services
{
    public class TibiaParser
    {
        private IWebDriver webDriver;

        public TibiaParser()
        {
            webDriver = WebDriverHelper.SetupWebDriver();
        }

        public Option<TibiaCharacterDTO> GetTibiaCharacter(string charName)
        {
            var tibiaCharacter = GetTibiaCharacterFromWeb(charName);

            return tibiaCharacter;
        }

        private Option<TibiaCharacterDTO> GetTibiaCharacterFromWeb(string charName)
        {
            var charTable = GetCharacterTableFromTibiaWebsite(charName);
            
            var tibiaCharacter = charTable.HasValue
                ? MapCharacterTableToTibiaCharacter(charTable.Value)
                : Option.None;

            return tibiaCharacter;
        }

        private Option<TibiaCharacterDTO> MapCharacterTableToTibiaCharacter(string[] characterTable)
        {
            var characterProperties = ParseTableToTibiaCharacterProperties(characterTable);
            var tibiaCharacter = MapCharacterPropertiesToTibiaCharacter(characterProperties);

            return tibiaCharacter;
        }

        private Option<string[]> GetCharacterTableFromTibiaWebsite(string charName)
        {
            string characterInfoText = GetTableContentFromTibiaWebsite(charName);

            string[] characterTable = characterInfoText.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);

            //If we can't find the tibia character we search for we want to end the call.
            if (characterTable.Any(row => row.Contains("Could not find character")))
            {
                return Option.None;
            }

            return Option.Some(characterTable);
        }

        private string GetTableContentFromTibiaWebsite(string charName)
        {
            string url = UrlHelper.FormatTibiaCharacterUrl(charName);
            webDriver.Navigate().GoToUrl(url);
            var boxContentElement = webDriver.FindElement(By.ClassName("BoxContent"));
            webDriver.Dispose();
            string characterInfoText = boxContentElement.Text;

            return characterInfoText;
        }

        private IEnumerable<KeyValuePair<string, string>> ParseTableToTibiaCharacterProperties(string[] characterTable)
        {
            var characterProperties = characterTable
                .Where(tableRow => tableRow.Contains(':'))
                .Select(tableRow =>
                {
                    return FormatTableRowToTibiaCharProperty(tableRow);
                });

            return characterProperties;
        }

        private KeyValuePair<string, string> FormatTableRowToTibiaCharProperty(string tableRow)
        {
            var tibiaCharProperty = tableRow.Split(':')
                .Select(lineValue => lineValue.Trim());
            
            var propertyTitle = tibiaCharProperty.ElementAt(0);
            var propertyValue = tibiaCharProperty.ElementAt(1);

            return new KeyValuePair<string, string>(propertyTitle, propertyValue);
        }

        private Option<TibiaCharacterDTO> MapCharacterPropertiesToTibiaCharacter(IEnumerable<KeyValuePair<string, string>> characterProperties)
        {
            try
            {
                var tibiaCharacter = new TibiaCharacterDTO(
                    name: characterProperties.First(property => property.Key == "Name").Value,
                    vocation: characterProperties.First(property => property.Key == "Vocation").Value,
                    guild: characterProperties.First(property => property.Key == "Guild Membership").Value,
                    level: int.Parse(characterProperties.First(property => property.Key == "Level").Value),
                    world: characterProperties.First(property => property.Key == "World").Value
                );

                return tibiaCharacter;
            }
            catch (Exception ex)
            {
                //Log ex
                return Option.None;
            }
        }
    }
}
