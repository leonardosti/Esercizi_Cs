using System;
using System.Runtime.CompilerServices;
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
            int n = 0;
            bool trMarca = false, trModello = false;
            string risposta, marca, modello;
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
                Console.Clear();
                Console.WriteLine("Vuoi inserire un altra auto? (si/no)");
                risposta = Console.ReadLine().ToLower();
                Console.WriteLine();
            } while (risposta == "si");
            Console.WriteLine("Vuoi cercare un auto nella concessionaria?");
            risposta = Console.ReadLine();
            Console.Clear();
            if (risposta == "si")
            {
                Console.WriteLine("Inserisci la marca da cercare");
                marca = Console.ReadLine();
                Console.WriteLine("Inserisci il modello da cercare");
                modello = Console.ReadLine();
                Cerca(ref trMarca, ref trModello, marca, modello, auto, n);
                if (trMarca && trModello)
                {
                    Console.WriteLine("Auto presente nella concessionaria\n");
                }
                else
                {
                    Console.WriteLine("Auto non presente nella concessionaria\n");
                }
            }
            Visualizza(auto, n);
            Console.ReadLine();
        }
        // Definizione: Inserire il marca, modello e prezzo dell'auto
        // Parametri:
        // Input: true 
        // Output: auto
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
        // Definizione: Output marca, modello, targa e prezzo dell'auto
        // Parametri:
        // Input: array auto, contatore n 
        // Output: void
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
        // Definizione: Generare il numero della targa
        // Parametri:
        // Input: auto.targa per riferimento
        // Output void
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
        // Definizione: Cercare se un auto è presente tramite marca modello
        // Parametri:
        // Input: trMarca - trModello per riferimento, marca, modello, auto, n
        // Output void
        static void Cerca(ref bool trMarca,ref bool trModello, string marca, string modello, Vettura[] auto, int n)
        {
            for (int i = 0; i < n && !trMarca && !trModello; i++)
            {
                trMarca = auto[i].marca == marca;
                trModello = auto[i].modello == modello;
            }
        }
    }
}
