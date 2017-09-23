using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public class Dog : Animal
    {
        public Dog(string name)
        {
            Name = name;
            HP = 150;
            Mana = 0;
            Damage = 25;
            Armor = 20;
            Agility = 20;
        }
    }
}
