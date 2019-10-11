﻿using HtmlAgilityPack;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TibiaParser
    {

        private HtmlWeb web;

        public TibiaParser()
        {
            web = new HtmlWeb();
        }

        public async Task<TibiaCharacter> GetTibiaCharacterAsync(string charName)
        {
            string formattedName = charName.Replace(" ", "+");
            string path = @"https://secure.tibia.com/community/?subtopic=characters&name=" + formattedName;

            TibiaCharacter tibiaCharacter = await GetTibiaCharacterFromWebAsync(web, path, charName);

            return tibiaCharacter;
        }

        private async Task<TibiaCharacter> GetTibiaCharacterFromWebAsync(HtmlWeb web, string path, string charName)
        {
            var htmlDoc = await web.LoadFromWebAsync(path);
            TibiaCharacter tibiaCharacter = new TibiaCharacter();
            tibiaCharacter.Name = charName;


            HtmlNode characterNotFound = htmlDoc.DocumentNode.SelectSingleNode("//table/tr/td[contains(., 'Could not find character')]");

            if (characterNotFound != null)
            {
                return null;
            }

            foreach (HtmlNode row in htmlDoc.DocumentNode.SelectNodes("//div[@id=\"characters\"]//table/tr/td"))
            {
                string rowTitle = row.InnerText;
                switch (rowTitle)
                {
                    case "Vocation:":
                        string vocation = HtmlEntity.DeEntitize(row.NextSibling.InnerText).Replace("\u00A0", " ");
                        string[] promotedVocation = vocation.Split(' ');
                        if (promotedVocation.Length == 2)
                        {
                            tibiaCharacter.Vocation = promotedVocation[1];
                        }
                        else
                        {
                            tibiaCharacter.Vocation = vocation;
                        }
                        break;
                    case "Level:":
                        tibiaCharacter.Level = Int32.Parse(HtmlEntity.DeEntitize(row.NextSibling.InnerText));
                        break;
                    case "World:":
                        string world = HtmlEntity.DeEntitize(row.NextSibling.InnerText);
                        tibiaCharacter.World = world.Replace("\u00A0", " ");
                        break;
                    case "Guild&#160;Membership:":
                        string guildName = HtmlEntity.DeEntitize(row.NextSibling.SelectSingleNode("a").InnerText);
                        tibiaCharacter.Guild = guildName.Replace("\u00A0", " ");
                        break;
                }
            }

            return tibiaCharacter;
        }

        public async Task<List<string>> GetCharacterNamesFromGuildAsync(string guildName)
        {
            string formattedGuildName = guildName.Replace("\u00A0", "+");
            string path = @"https://secure.tibia.com/community/?subtopic=guilds&page=view&GuildName=" + formattedGuildName;

            var htmlDoc = await web.LoadFromWebAsync(path);

            HtmlNode guildNotFound = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='InnerTableContainer']/table/tr/td");

            if (guildNotFound.InnerText == "An internal error has occurred. Please try again later!")
            {
                return null;
            }

            var characters = new List<string>();

            foreach (HtmlNode row in htmlDoc.DocumentNode.SelectNodes("//td/a"))
            {
                if (row.GetAttributeValue("href", "unknown").Contains("characters&name"))
                {
                    string characterName = HtmlEntity.DeEntitize(row.InnerText);
                    characterName = characterName.Replace("\u00A0", " ");
                    characters.Add(characterName);
                }
            }

            return characters;
        }

        public async Task<List<TibiaCharacter>> GetOnlineCharactersAsync(string worldName)
        {
            string path = "https://secure.tibia.com/community/?subtopic=worlds&world=" + worldName;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(path);

            List<TibiaCharacter> characters = new List<TibiaCharacter>();

            foreach (HtmlNode row in htmlDoc.DocumentNode.SelectNodes("//table[@class='Table2']//tr[@class='Odd' or @class='Even']/td//a[not(@name)]"))
            {
                string characterName = HtmlEntity.DeEntitize(row.InnerText);
                characterName = characterName.Replace("\u00A0", " ");
                TibiaCharacter character = await GetTibiaCharacterAsync(characterName);
                characters.Add(character);
            }

            return characters;
        }
    }
}
