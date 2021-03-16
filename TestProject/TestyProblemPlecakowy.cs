using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie01;
using System;

namespace TestZadanie01
{
    [TestClass]
    public class TestyProblemPlecakowy
    {

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

        [TestMethod]
        public void TestPrzedmiotSpelniaWymagania()
        {
            // Arrange
            int pojemnosc = 10;
            int [] waga = { 10 };
            int [] wartosc = { 250 };
            int obiekty = 1;
            // Act
            int wynik = Algorytm(pojemnosc, waga, wartosc, obiekty);
            // Assert
            Assert.IsTrue(wynik > 0);
        }
        [TestMethod]
        public void TestPrzedmiotNieSpelniaWymagania()
        {
            int pojemnosc = 2;
            int[] waga = { 4 };
            int[] wartosc = { 10 };
            int obiekty = 1;

            int wynik = Algorytm(pojemnosc, waga, wartosc, obiekty);
            Assert.IsFalse(wynik > 0);
        }
        [TestMethod]
        public void TestPrzedmiotuDlaKonkretnegoSeed()
        {
            // Wzieto seed 323
            int obiekty = 5;
            int pojemnosc = 32;
            int[] wartosc = { 1, 4, 5, 10, 21 };
            int[] waga = { 15, 5, 22, 9, 28 };

            int wynik = Algorytm(pojemnosc, waga, wartosc, obiekty);

            // Wynik obliczony
            int wynik_obl = 21;
            Assert.AreEqual(wynik_obl, wynik);
        }
        [TestMethod]
        public void TestKolejnosciPrzedmiotow()
        {
            // Wzieto seed 323
            int obiekty = 5;
            int pojemnosc = 32;
            int[] wartosc = { 4, 1, 21, 10, 5 };
            int[] waga = { 5, 15, 28, 9, 22 };

            int wynik = Algorytm(pojemnosc, waga, wartosc, obiekty);

            // Porownanie wynikow
            int wynik_obl = 21;
            Assert.AreEqual(wynik_obl, wynik);
        }
    }
}
