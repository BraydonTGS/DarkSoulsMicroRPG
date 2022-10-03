﻿using System;
namespace DarkSoulsMicroRPG.Interfaces
{
    public interface IFightable
    {
        public bool IsDead { get; }
        public bool IsAlive { get; }

        public void TakeDamage(int damage);

        public void Attack(ICharacter character);

    }
}

