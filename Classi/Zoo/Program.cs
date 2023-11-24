using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // lo Zoo di casa mia
            List<AnimaleDomestico> animale = new List<AnimaleDomestico>();
            string[] opzioni = {"Inserisci", "Visualizza", "Esci"};
            int scelta = Menu(opzioni);
            switch (scelta)
            {
                case 0:
                    Input();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        static int Menu(string[] opzioni)
        {
            int scelta = 0;
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
        static void Input(List<AnimaleDomestico> animale1)
        {
            Console.WriteLine("Inserire la specie:");
            animale1.GetSpecie(Console.ReadLine());
            Console.WriteLine("Inserire la razza:");
            animale1.GetRazza(Console.ReadLine());
            Console.WriteLine("Inserire la cibo:");
            animale1.GetCibo(Console.ReadLine());
            Console.WriteLine("Inserire la verso:");
            animale1.GetVerso(Console.ReadLine());
            Console.WriteLine("Inserire la quantità:");
            animale1.GetQuantita(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Inserire lo stato:");
            animale1.GetMangiato(Console.ReadLine());
        }
    }
}
