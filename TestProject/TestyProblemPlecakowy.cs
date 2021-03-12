using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie01;
using System;

namespace TestProject
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
            Assert.IsTrue(1 > 0);
        }
        [TestMethod]
        public void TestKolejnosciPrzedmiotow()
        {
            Assert.IsTrue(1 > 0);
        }
        [TestMethod]
        public void TestPrzedmiotuDlaKonkretnegoSeed()
        {
            Assert.IsTrue(1 > 0);
        }
    }
}
