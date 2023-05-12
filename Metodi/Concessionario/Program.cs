using System;
using System.Runtime.InteropServices;

namespace Concessionario
{
    class Program
    {
        struct Vettura
        {
            public string marca;
            public string modello;
            public string targa;
            public double prezzo;
        }
        static void Main(string[] args)
        {
            const int maxAuto = 3;
            bool valida;
            int n = 0;
            string risposta;

            Vettura[] auto = new Vettura[maxAuto];
            do
            {
                Console.Clear();
                if (n < maxAuto)
                {
                    auto[n] = InsAuto(true);
                    n++;
                }
                else
                {
                    Console.WriteLine("La concessionaria è piena");
                }
                Console.WriteLine("vuoi inserire un altra auto? (si/no)");
                risposta = Console.ReadLine().ToLower();
            } while (risposta == "si");
            Visualizza(auto, n);
            Console.ReadLine();
        }
        static Vettura InsAuto(bool valida)
        {
            Vettura auto = new Vettura();
            Console.WriteLine("Inserisci la marca");
            auto.marca = Console.ReadLine();
            Console.WriteLine("Inserisci il modello");
            auto.modello = Console.ReadLine();
            if (valida)
            {
                Genera(ref auto.targa);
            }
            Console.WriteLine("Inserisci il prezzo");
            auto.prezzo = double.Parse(Console.ReadLine());
            return auto;
        }
        static void Visualizza(Vettura[] auto, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Marca {i + 1}° auto: {auto[i].marca}");
                Console.WriteLine($"Modello {i + 1}° auto: {auto[i].modello}");
                Console.WriteLine($"Targa {i + 1}° auto: {auto[i].targa}");
                Console.WriteLine($"Prezzo {i + 1}° auto: {auto[i].prezzo}");
                Console.WriteLine();
            }
        }
        static void Genera(ref string targa)
        {
            Random casuale = new Random();
            for (int i = 0; i < 7; i++)
            {
                if (i < 2 || i > 4)
                {
                    targa += (char)casuale.Next(65, 91);
                }
                else
                {
                    targa += casuale.Next(0, 10);
                }
            }
        }
    }
}
