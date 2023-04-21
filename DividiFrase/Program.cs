using System;

namespace DividiFrase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string riga = "", frase;
            const int divisore = 34;
            Console.WriteLine("Inserisci una frase");
            frase = Console.ReadLine();
            if (frase != "")
            {
                Console.WriteLine("Frase divisa in 34 caratteri:");
                do
                {
                    if (frase.Length >= divisore)
                    {
                        riga = frase.Substring(0, divisore);
                        Console.WriteLine(riga);
                    }
                    else
                    {
                        riga = frase;
                        Console.WriteLine(riga);
                    }
                    frase = frase.Remove(0, riga.Length);
                } while (frase.IndexOf(' ') != -1);
            }
            else
            {
                Console.WriteLine("Non puoi inserire una frase nulla");
            }
            Console.ReadLine();
        }
    }
}
