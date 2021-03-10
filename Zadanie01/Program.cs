using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorCS;

namespace Zadanie01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj ile obiektow chcesz wylosowac:");
            int obiekty = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ile miejsca ma miec plecak:");
            int pojemnosc = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj dowolny seed:");
            int seed = int.Parse(Console.ReadLine());

            RandomNumberGenerator rng = new RandomNumberGenerator(seed); //tutaj tworzymy obiektb

            Console.WriteLine("PROGRAM:");

            int[] tablica = new int[obiekty];

            for (int i=0; i<obiekty; i++)
            {
                tablica[i] = rng.nextInt(1, 30);

                Console.WriteLine(tablica[i]);
            }

            // SPRAWDZNIE 
            Console.WriteLine("Sprawdzenie");
            Console.WriteLine("Obiekty = {0:D}", obiekty);
            Console.WriteLine("Pojemnosc = {0:D}", pojemnosc);
            Console.WriteLine("Seed = {0:D}", seed);
            Console.WriteLine("Koniec programu");
        }
    }
}
