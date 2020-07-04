using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class TibiaCharacterDTO
    {
        public string Name { get; }
        public string Guild { get; }
        public string Vocation { get; }
        public int Level { get; }
        public string World { get; }
        public string Comment { get; set; }

        public TibiaCharacterDTO(string name, string vocation, string guild, int level, string world, string comment)
        {
            Name = name;
            Vocation = vocation;
            Guild = guild;
            Level = level;
            World = world;
            Comment = comment;
        }
    }
}
