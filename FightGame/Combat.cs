using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public class Combat<T1, T2> where T1 : IAnimal where T2 : IAnimal
    {
        private T1 _fighter1;
        private T2 _fighter2;

        public Combat(T1 fighter1, T2 fighter2)
        {
            _fighter1 = fighter1;
            _fighter2 = fighter2;
        }


        public void IntroduceFighters()
        {
            _fighter1.Introduce();
            _fighter2.Introduce();
        }

        private bool SetFirstTurn()
        {
            Console.WriteLine("Dowolny klawisz zaczyna walkę!");

            bool MyTurn;
            if (_fighter1.IsMyTurn() > _fighter2.IsMyTurn())
            {
                MyTurn = true;
                Console.WriteLine($"{_fighter1.Name} jest szybszy i uderza pierwszy!\n\n");
            }
            else
            {
                MyTurn = false;
                Console.WriteLine($"{_fighter2.Name} jest szybszy i uderza pierwszy!\n\n");
            }

            return MyTurn;
        }

        private bool AreBothAlive()
        {
            return _fighter1.IsAlive() && _fighter2.IsAlive();
        }

        public void Fight()
        {
            bool MyTurn = SetFirstTurn();

            while (AreBothAlive())
            {
                Console.ReadKey();
                Console.Clear();
                PrintStatistics();
                if (MyTurn)
                {
                    Strike(_fighter1, _fighter2);
                }
                else
                {
                    Strike(_fighter2, _fighter1);
                }
                MyTurn = !MyTurn;
            }
        }

        private void PrintStatistics()
        {
            Console.Write($"{_fighter1.GetType().FullName.Substring(10)}");
            Console.WriteLine($"{_fighter2.GetType().FullName.Substring(10),63}");

            Console.Write($"{_fighter1.Name}");
            Console.WriteLine($"{_fighter2.Name,62}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{_fighter1.HP} HP");
            Console.WriteLine($"{_fighter2.HP,60} HP");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        private void Strike<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            Random rnd = new Random();

            if (rnd.Next(1, 100) > fighter2.Agility - rnd.Next(10, 20))
            {
                var hit = fighter1.Attack();
                var armored = (fighter2.Armor * hit) / 100;
                var armoredHit = hit - armored;
                fighter2.HP -= armoredHit;
                Console.WriteLine("\n\n\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{fighter1.Name}".PadLeft(40));
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"zadał {hit} punktów obrażeń {fighter2.Name} (zaabsorbowano {armored}) pozostało {fighter2.HP} życia");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"{fighter1.Name}".PadLeft(40));
                Console.WriteLine($"atakuje lecz {fighter2.Name} uniknął ataku!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void FightSummary()
        {
            if (!_fighter1.IsAlive())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n\n{_fighter1.Name} przegrał!!!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n\n{_fighter2.Name} przegrał!!!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Dowolny klawisz zamyka okno");
            Console.ReadKey();

        }
    }
}
