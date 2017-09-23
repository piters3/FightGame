using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public abstract class Animal: IAnimal
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Agility { get; set; }

        public static Random randomize = new Random();

        public bool IsAlive()
        {
            if (HP > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Attack()
        {
            int hit = Damage + randomize.Next(1, 10);
            return hit;
        }

        public int IsMyTurn()
        {
            return Agility + randomize.Next(1, 10);
        }

        public void Introduce()
        {
            Console.WriteLine($"Imię wojownika: {Name}");
            Console.WriteLine($"Życie: {HP}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Zwinność: {Agility}");
            Console.WriteLine($"Obrażenia: {Damage}");
            Console.WriteLine($"Zbroja: {Armor}\n\n");
        }
    }
}
