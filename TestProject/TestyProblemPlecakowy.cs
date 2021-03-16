using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie01DesktopApp;

namespace Zadanie01DesktopApp.Tests
{
    [TestClass()]
    public class TestyProblemPlecakowy
    {
        public static int Algorytm(int backpackCapacity, int[] waga, int[] wartosc, int objectAmount)
        {
            int[,] K = new int[objectAmount + 1, backpackCapacity + 1];

            for (int i = 0; i <= objectAmount; ++i)
            {
                for (int w = 0; w <= backpackCapacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (waga[i - 1] <= w)
                        K[i, w] = Math.Max(wartosc[i - 1] + K[i - 1, w - waga[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }
            return K[objectAmount, backpackCapacity];
        }

        [TestMethod()]
        public void Test1()
        {
            // Arrange
            int backpackCapacity = 10;
            int[] waga = { 10 };
            int[] wartosc = { 250 };
            int objectAmount = 1;
            // Act
            int wynik = Algorytm(backpackCapacity, waga, wartosc, objectAmount);
            // Assert
            Assert.IsTrue(wynik > 0);
        }

        [TestMethod()]
        public void Test2()
        {
            int backpackCapacity = 2;
            int[] waga = { 4 };
            int[] wartosc = { 10 };
            int objectAmount = 1;

            int wynik = Algorytm(backpackCapacity, waga, wartosc, objectAmount);
            Assert.IsFalse(wynik > 0);
        }

        [TestMethod()]
        public void Test3()
        {
            // Wzieto seed 323
            int objectAmount = 5;
            int backpackCapacity = 32;
            int[] wartosc = { 1, 4, 5, 10, 21 };
            int[] waga = { 15, 5, 22, 9, 28 };

            int wynik = Algorytm(backpackCapacity, waga, wartosc, objectAmount);

            // Wynik obliczony
            int wynik_obl = 21;
            Assert.AreEqual(wynik_obl, wynik);
        }

        [TestMethod()]
        public void Test4()
        {
            // Wzieto seed 323
            int objectAmount = 5;
            int backpackCapacity = 32;
            int[] wartosc = { 4, 1, 21, 10, 5 };
            int[] waga = { 5, 15, 28, 9, 22 };

            int wynik = Algorytm(backpackCapacity, waga, wartosc, objectAmount);

            // Porownanie wynikow
            int wynik_obl = 21;
            Assert.AreEqual(wynik_obl, wynik);
        }
    }
}