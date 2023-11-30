using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Program
    {
        const int nMax = 4;
        static void Main(string[] args)
        {
            // lo Zoo di casa mia
            List<AnimaleDomestico> zoo = new List<AnimaleDomestico>();
            string[] opzioni = { "Inserisci", "Visualizza", "Esci" };
            int scelta;

            do
            {
                scelta = Menu(opzioni);
                switch (scelta)
                {
                    case 0:
                        if (nMax <= zoo.Count)
                        {
                            AnimaleDomestico animale = new AnimaleDomestico();

                            animale.SetSpecie(Console.ReadLine());
                            animale.SetRazza(Console.ReadLine());
                            animale.SetCibo(Console.ReadLine());
                            animale.SetVerso(Console.ReadLine());
                            animale.SetQuantita(InputInteri());
                        }
                        break;
                    case 1:
                        if (nMax <= zoo.Count)
                        {
                            zoo.ForEach(a => Console.WriteLine(a.ToString()));
                        }
                        else
                        {
                            Console.WriteLine("Zoo vuoto");
                        }
                        break;
                    default:
                        Console.WriteLine("Errore nella scelta");
                        break;
                }
            } while (scelta == opzioni.Length);
            Console.ReadLine();
        }
        static int Menu(string[] opzioni)
        {
            int scelta;
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"{i + 1}- {opzioni[i]}");
            }
            try
            {
                scelta = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception read)
            {
                Console.WriteLine(read.Message);
                throw;
            }
            return scelta;
        }
        static int InputInteri()
        {
            int n;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
            return n;
        }
    }
}
