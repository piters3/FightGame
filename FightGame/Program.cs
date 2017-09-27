using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeWindow();

            Cat fighter1 = new Cat("Pazur");
            Cat cat2 = new Cat("Mleczarz");
            Dog fighter2 = new Dog("Azor");

            Combat<Cat, Dog> CatVsDog = new Combat<Cat, Dog>(fighter1, fighter2);

            CatVsDog.IntroduceFighters();
            CatVsDog.Fight();
            CatVsDog.FightSummary();
        }

        private static void InitializeWindow()
        {
            Console.CursorVisible = false;

            for (var percentComplete = 0; percentComplete <= 100; percentComplete++)
            {
                var title = ($"Ładownie gry {percentComplete} %");
                Console.Title = title;
                Thread.Sleep(50);
                PrintLoadingSymbol(percentComplete);
            }

            Console.SetWindowSize(70, 20);
            Console.SetBufferSize(70, 20);

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Title = "Fight Game";
        }

        private static void PrintLoadingSymbol(int i)
        {
            char[] Symbols = { '|', '/', '-', '\\' };

            Console.CursorLeft = Console.WindowWidth / 2;
            Console.CursorTop = Console.WindowHeight / 2;

            Console.Write(Symbols[i % Symbols.Length]);

            i++;
            if (i == Symbols.Length)
            {
                i = 0;
            }
        }
    }
}
