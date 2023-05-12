using System;

namespace Spazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase = "la  mamma    va al  mercato   a comprare  le    albicocche";
            string parola;
            Console.WriteLine("Input:");
            Console.WriteLine(frase);
            Console.WriteLine("Output:");
            do
            {
                if (frase.IndexOf(' ') != 0)
                {
                    parola = frase.Substring(0, frase.IndexOf(' ') + 1);
                    Console.WriteLine(parola);
                }
                frase = frase.Remove(0, frase.IndexOf(' ') + 1);
            } while (frase.IndexOf(' ') != -1);
            Console.WriteLine(frase);
            Console.ReadLine();
        }
    }
}
