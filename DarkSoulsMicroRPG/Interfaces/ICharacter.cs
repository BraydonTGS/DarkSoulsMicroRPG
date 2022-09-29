using System;
namespace DarkSoulsMicroRPG.Interfaces
{
    public interface ICharacter
    {
        public int CharacterId { get; set; }

        public string CharacterArt { get; set; }

        public ConsoleColor Color { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int MaxHealth { get; set; }

        public int Health { get; set; }
    }
}

