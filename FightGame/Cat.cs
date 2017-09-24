using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            Name = name;
            HP = 100;
            Mana = 0;
            Damage = 18;
            Armor = 10;
            Agility = 55;
        }
    }
}
