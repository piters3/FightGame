using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("Pazur");
            Cat cat2 = new Cat("Mleczarz");
            Dog dog1 = new Dog("Azor");

            var fighter1 = cat1;
            var fighter2 = dog1;

            IntroduceFighters(fighter1, fighter2);
            bool MyTurn = SetFirstTurn(fighter1, fighter2);
            Fight(fighter1, fighter2, MyTurn);
            FightSummary(fighter1, fighter2);
        }


        private static void IntroduceFighters<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            fighter1.Introduce();
            fighter2.Introduce();
        }

        private static void FightSummary<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            if (!fighter1.IsAlive())
            {
                Console.WriteLine($"\n\n{fighter1.Name} przegrał!!!");
            }
            else
            {
                Console.WriteLine($"\n\n{fighter2.Name} przegrał!!!");
            }
            Console.WriteLine("Dowolny klawisz zamyka okno");
            Console.ReadKey();

        }

        private static void Fight<T1, T2>(T1 fighter1, T2 fighter2, bool MyTurn) where T1 : IAnimal where T2 : IAnimal
        {
            while (AreBothAlive(fighter1, fighter2))
            {
                Console.ReadKey();
                if (MyTurn)
                {
                    Strike(fighter1, fighter2);
                }
                else
                {
                    Strike(fighter2, fighter1);
                }
                MyTurn = !MyTurn;
            }
        }

        private static void Strike<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            var hit = fighter1.Attack();
            var armored = (fighter2.Armor * hit) / 100;
            var armoredHit = hit - armored;
            fighter2.HP -= armoredHit;
            Console.WriteLine($"{fighter1.Name}");
            Console.WriteLine($"\t zadał {hit} punktów obrażeń {fighter2.Name} (zaabsorbowano {armored}) pozostało {fighter2.HP} życia");
        }

        private static bool AreBothAlive<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            return fighter1.IsAlive() && fighter2.IsAlive();
        }

        private static bool SetFirstTurn<T1, T2>(T1 fighter1, T2 fighter2) where T1 : IAnimal where T2 : IAnimal
        {
            Console.WriteLine("Dowolny klawisz zaczyna walkę!");

            bool MyTurn;
            if (fighter1.IsMyTurn() > fighter2.IsMyTurn())
            {
                MyTurn = true;
                Console.WriteLine($"{fighter1.Name} jest szybszy i uderza pierwszy!\n\n");
            }
            else
            {
                MyTurn = false;
                Console.WriteLine($"{fighter2.Name} jest szybszy i uderza pierwszy!\n\n");
            }

            return MyTurn;
        }
    }
}
