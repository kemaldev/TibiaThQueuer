using Common.Helpers;
using Functional.Option;
using Models.DTOs;
using Models.DTOs.Mappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TibiaApiService
    {
        private readonly HttpClient _client;

        public TibiaApiService()
        {
            _client = new HttpClient();
        }

        public async Task<Option<TibiaCharacterDTO>> GetTibiaCharacterAsync(string characterName)
        {
            HttpResponseMessage response = await _client.GetAsync(UrlHelper.FormatGetTibiaCharacterUrl(characterName));
            if(response.IsSuccessStatusCode)
            {
                string jsonResponseString = await response.Content.ReadAsStringAsync();

                TibiaCharacterQuery tibiaCharacter = JsonConvert.DeserializeObject<TibiaCharacterQuery>(jsonResponseString);

                return Option.Some(tibiaCharacter.ToTibiaCharacterDTO());
            }
            else
            {
                return Option.None;
            }
        }
    }
}
