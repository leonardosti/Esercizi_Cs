using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scelta;
            string intestazione = "";
            string[] opzioni = { "Inserisci", "Cerca", "Modifica", "Visualizza", "Elimina", "Esci" };
            //Console.BackgroundColor = ConsoleColor.Cyan;
            //Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                scelta = Menu(opzioni, intestazione, 10, 0);
                Console.Clear();
                if (scelta == -1)
                {
                    Errore("Errore nella scelta!!");
                    Console.ReadLine();
                }
                else
                {
                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("Inserisci");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Cerca");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Modifica");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Visualizza");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Elimina");
                            Console.ReadLine();
                            break;
                    }
                }
                Console.Clear();
            } while (scelta != 6);

            Console.ReadLine();
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y)
        {
            int scelta = 0;
            bool valida = true;

            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                y++;
                Console.WriteLine($"{i + 1} - {opzioni[i]}");
            }
            valida = int.TryParse(Console.ReadLine(), out scelta);
            if (!valida)
            {
                Errore("Errore nella scelta!!");
            }
            if (scelta <= 6 && scelta >= 1)
            {
                return scelta;
            }
            else
            {
                return -1;
            }
        }
        static void Errore(string messaggio)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messaggio);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
