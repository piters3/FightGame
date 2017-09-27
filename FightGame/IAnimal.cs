using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public interface IAnimal
    {
        string Name { get; }
        int HP { get; set; }
        int Mana { get; }
        int Damage { get; }
        int Armor { get; }
        int Agility { get; }
        bool IsAlive();
        void Introduce();
        int Attack();
        int IsMyTurn();
    }
}
