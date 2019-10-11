using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class TibiaCharacterDTO
    {
        public int TibiaCharacterId { get; set; }
        public string Name { get; set; }
        public string Vocation { get; set; }
        public int Level { get; set; }
        public string World { get; set; }
        public string PVPType { get; set; }
    }
}
