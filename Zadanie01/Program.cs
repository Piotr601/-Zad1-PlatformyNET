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
        // Wczytywanie danych
            Console.WriteLine("Podaj ile obiektow chcesz wylosowac:");
            int obiekty = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj limit plecaka");
            int pojemnosc = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj dowolny seed:");
            int seed = int.Parse(Console.ReadLine());

        // Tworzymy nowy obiekt
            RandomNumberGenerator rng = new RandomNumberGenerator(seed);

            Console.WriteLine();
            Console.WriteLine("PROGRAM:");
        
        // Zdefiniowanie tablic i zmiennych
            int pom = 0;
            int[] wartosc = new int[obiekty];
            int[] waga = new int[obiekty];

        // Losujemy obiekty: wartosc i wage
            for (int i=0; i<obiekty; i++)
            {
                wartosc[i] = rng.nextInt(1, 50);
                waga[i] = rng.nextInt(1, 30);

                Console.WriteLine("{0:D}, {1:D}", wartosc[i], waga[i]);
                
             /*
              * TEST
              * Sprawdzenie czy cokolwiek zmieści się do plecaka
             */ 
                if (wartosc[i] > pojemnosc)
                {
                    pom++;
                    if(pom==obiekty)
                    { 
                        Console.WriteLine("Brak rozwiazan");
                        break;
                    }
                }
            }

        // Sortowanie po najwiekszej wartosci
            int pom2;
            for (int j = 0; j < obiekty; j++)
            {
                for (int i = 0; i < obiekty; i++)
                {
                    if (wartosc[i] < wartosc[j])
                    {
                        pom2 = wartosc[i];
                        wartosc[i] = wartosc[j];
                        wartosc[j] = pom2;

                        pom2 = waga[i];
                        waga[i] = waga[j];
                        waga[j] = pom2;
                    }
                    else if(wartosc[i] == wartosc[j])
                    {
                        if(waga[i] > waga[j])
                        {
                            pom2 = wartosc[i];
                            wartosc[i] = wartosc[j];
                            wartosc[j] = pom2;

                            pom2 = waga[i];
                            waga[i] = waga[j];
                            waga[j] = pom2;
                        }
                    }
                }
            }

        // Wyswietlenie po sortowaniu
            Console.WriteLine();
            for(int i=0; i< obiekty; i++)
            {
                Console.WriteLine("{0:D}, {1:D}", wartosc[i], waga[i]);
            }
        // 10 32 323

        // Sprawdzenie algo
            int wynik = Algorytm(pojemnosc, waga, wartosc, obiekty);
            Console.WriteLine("WYNIK MAX WARTOSC W PLECAKU: {0:D}",wynik);

            // Sprawdzenie poprawnosci danych
            Console.WriteLine();
            Console.WriteLine("Sprawdzenie");
            Console.WriteLine("Obiekty = {0:D}", obiekty);
            Console.WriteLine("Pojemnosc = {0:D}", pojemnosc);
            Console.WriteLine("Seed = {0:D}", seed);

            Console.WriteLine("Koniec programu");
            Console.ReadLine();
        }

        public static int Algorytm(int pojemnosc, int[] waga, int[] wartosc, int ilosc)
        {
            int[,] K = new int[ilosc + 1, pojemnosc + 1];

            for (int i = 0; i <= ilosc; ++i)
            {
                for (int w = 0; w <= pojemnosc; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (waga[i - 1] <= w)
                        K[i, w] = Math.Max(wartosc[i - 1] + K[i - 1, w - waga[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[ilosc, pojemnosc];
        }
    }
}
