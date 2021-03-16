using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneratorCS;

namespace Zadanie01DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int seed = 0;
        public int objectAmount = 0;
        public int backpackCapacity = 0;
        public int result = 0;

        bool data1 = false;
        bool data2 = false;
        bool data3 = false;

        public static int Algorytm(int backpackCapacity, int[] waga, int[] wartosc, int ilosc)
        {
            int[,] K = new int[ilosc + 1, backpackCapacity + 1];

            for (int i = 0; i <= ilosc; ++i)
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

            return K[ilosc, backpackCapacity];
        }
        public int Algorithm_Execution()
        {
            // Tworzymy nowy obiekt
            RandomNumberGenerator rng = new RandomNumberGenerator(seed);
            int wynik = 0;
            // Zdefiniowanie tablic i zmiennych
            int pom = 0;
            int[] wartosc = new int[objectAmount];
            int[] waga = new int[objectAmount];

            // Losujemy obiekty: wartosc i wage
            for (int i = 0; i < objectAmount; i++)
            {
                wartosc[i] = rng.nextInt(1, 50);
                waga[i] = rng.nextInt(1, 30);

                /*
                 * TEST
                 * Sprawdzenie czy cokolwiek zmieści się do plecaka
                */
                if (wartosc[i] > backpackCapacity)
                {
                    pom++;
                    if (pom == objectAmount)
                    {
                        break;
                    }
                }
            }

            // Sortowanie po najwiekszej wartosci
            int pom2;
            for (int j = 0; j < objectAmount; j++)
            {
                for (int i = 0; i < objectAmount; i++)
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
                    else if (wartosc[i] == wartosc[j])
                    {
                        if (waga[i] > waga[j])
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

            // 10 32 323

            // Sprawdzenie algo
            wynik = Algorytm(backpackCapacity, waga, wartosc, objectAmount);

            return wynik;
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(this.textBox1.Text != string.Empty)
            {
                int bpCapacity;
                bpCapacity = Int32.Parse(this.textBox1.Text);
                // jesli da sie przekonwertowac na inta
                if (Convert.ToBoolean(bpCapacity))
                {
                    backpackCapacity = bpCapacity;
                    data1 = true;
                }
            }
            else
            {
                label6.Text = "0";
                data1 = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int objAmount;
            // jesli da sie przekonwertowac na inta
            objAmount = Int32.Parse(this.textBox2.Text);
            if (Convert.ToBoolean(objAmount))
            {
                objectAmount = objAmount;
                data2 = true;
            }
            else
            {
                label6.Text = "0";
                data2 = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int seedValue;
            seedValue = Int32.Parse(this.textBox3.Text);
            // jesli da sie przekonwertowac na inta
            if (Convert.ToBoolean(seedValue))
            {
                seed = seedValue;
                data3 = true;
            }
            else
            {
                label6.Text = "0";
                data3 = false;
            }
        }
 
        private void label6_TextChanged()
        {
            if (data1 && data2 && data3)
            {
                result = Algorithm_Execution();
                label6.Text = result.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6_TextChanged();
        }
    }
}
