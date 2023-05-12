using System;

namespace MarginaFrase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase;
            const int maxFrase = 80;
            do
            {
                Console.WriteLine("Inserisci la frase");
                frase = Console.ReadLine();
            } while (string.IsNullOrEmpty(frase));
            if (frase.Length > maxFrase)
            {
                frase = frase.Substring(0, maxFrase);
            }
            frase = Margina(frase);
            Console.WriteLine(frase);
            Console.ReadLine();
        }
        static string Margina(string frase)
        {
            string parola;
            int i = 0, x = 20;
            while (frase.Length > x)
            {
                if (frase[20] == ' ')
                {
                    parola = frase.Substring(0, x);
                    Console.WriteLine(parola);
                    frase = frase.Remove(0, x);
                }
                else
                {
                    while (frase[x] != ' ')
                    {
                        x--;
                        i++;
                    }
                    if (i >= x)
                    {
                        break;
                    }
                    else
                    {
                        parola = frase.Substring(0, (x - i));
                        Console.WriteLine(parola);
                        frase = frase.Remove(0, (x - i));
                    }
                }
                x = 20;
                i = 0;
            }
            return frase;
        }
    }
}
