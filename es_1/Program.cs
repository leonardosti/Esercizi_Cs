using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int volte, numero, resto;
            int[] cont = new int[10];
            Random casuale = new Random();
            Console.WriteLine("Quanti numeri vuoi generare?");
            volte = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numeri generati:");
            for (int i = 0; i < volte; i++)
            {
                numero = casuale.Next(0, 101);
                Console.WriteLine(numero);
                do
                {
                    resto = numero % 10;
                    numero = numero / 10;
                    cont[resto]++;
                } while (numero != 0);
            }
            for (int i = 0; i < cont.Length; i++)
            {
                Console.WriteLine("Il numero {0} è presente {1} volte", i, cont[i]);
            }
            Console.ReadLine();
        }
    }
}
