using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VettoreRipasso
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num;
            int dimensione = 7, estendi = 4;
            CreaVettore(out num, dimensione);
            Visualizza(num);
            EstendiVettore(ref num, estendi);
            Visualizza(num);
            NumeriDoppi(ref num);
            Visualizza(num);
            //Console.WriteLine(num[0]);
            Console.ReadLine();
        }
        static void CreaVettore(out int[] num, int dimensione)
        {
            num = new int[dimensione];
            Random casuale = new Random();
            for (int i = 0; i < dimensione; i++)
            {
                num[i] = casuale.Next(1, 101);
            }
        }
        static void Visualizza(int[] num)
        {
            //num[0] = 99;
            for(int i = 0; i < num.Length; i++)
            {

                Console.Write(num[i] + " ");
            }
            Console.WriteLine();
        }
        static void EstendiVettore(ref int[] num, int estensione)
        {
            int[] numeri = new int[num.Length + estensione];
            Random casuale = new Random();
            for ( int i = 0; i < numeri.Length; i++)
            {
                if (i < numeri.Length - estensione)
                {
                    numeri[i] = num[i];
                }
                else
                {
                    numeri[i] = casuale.Next(1, 101);
                }
            }
            num = numeri;//sostituisce l'indirizzo dell'array num con quello dell'array numeri, quindi adesso hanno lo stesso indirizzo
        }
        static void NumeriDoppi(ref int[] num)
        {
            int cont = 0, n = 0;
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 0; j < num.Length; j++)
                {
                    if (num[i] == num[j] && i != j)
                    {
                        num[i] = -1;
                        cont++;
                    }
                }
            }
            int[] singoli = new int[num.Length - cont];
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != -1)
                {
                    singoli[n] = num[i];
                    n++;
                }
            }
            num = singoli;
        }
    }
}
//realizzare un metodo che tolga gli elementi duplicati dal vettore num adattandone la dimensione (vettore sempre completo di valori)
