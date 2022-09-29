using System;
using DarkSoulsMicroRPG.Characters;
using DarkSoulsMicroRPG.Interfaces;

namespace DarkSoulsMicroRPG.Factory
{
    public static class CharacterFactory
    {
        public static ICharacter GetCharacter(int choice, string name)
        {
            switch (choice)
            {
                case 0:
                    return new Warrior(name);
                case 1:
                    return new Mage(name);
                case 2:
                    return new Thief(name);
                default:
                    return new Warrior(name);

            }

        }

    }
}

