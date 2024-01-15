using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RipassoFlotta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] opzioni = {
                    "Visualizza Flotta",
                    "Inserisci",
                    "Elimina Auto con codice/targa",
                    "Visualizza Auto con codice/targa",
                    "Ricerca Auto con numero di posti",
                    "Salva log",
                    "Esci"};
            Flotta flotta = new Flotta("Flotta 1");
            string nome = "flotta.txt";
            string path = Directory.GetCurrentDirectory() + "\\" + nome;

            flotta.Aggiungi("fiat", "panda", (NumeroPosti)3);
            flotta.Aggiungi("audi", "rs", (NumeroPosti)2);
            flotta.Aggiungi("toyota", "supra", (NumeroPosti)1);
            flotta.Aggiungi("lamborghini", "urus", (NumeroPosti)3);

            int scelta;
            do
            {
                Console.Clear();
                scelta = Menu(opzioni, "Autoconcessionaria");
                LeggiScelta(scelta, flotta, path);
            } while (scelta != opzioni.Length - 1);
        }
        static int Menu(string[] opzioni, string nome)
        {
            int scelta;
            Console.WriteLine(nome);
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] - {opzioni[i]}");
            }
            Console.WriteLine("Inserire scelta:");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > opzioni.Length)
            {
                Console.WriteLine("Inserire una scelta valida:");
            }
            Console.Clear();
            return --scelta;
        }
        static void LeggiScelta(int scelta, Flotta flotta, string path)
        {
            string stringa;
            switch (scelta)
            {
                case 0:
                    /*code*/
                    flotta.Stampa();
                    break;
                case 1:
                    /*code*/
                    string marca, modello;
                    do
                    {
                        Console.WriteLine("Inserire marca:");
                    } while (string.IsNullOrEmpty(marca = Console.ReadLine()));
                    do
                    {
                        Console.WriteLine("Inserire modello:");
                    } while (string.IsNullOrEmpty(modello = Console.ReadLine()));
                    int posti = Menu(Enum.GetNames(typeof(NumeroPosti)), "Inserire posti:");
                    flotta.Aggiungi(marca, modello, (NumeroPosti)posti);
                    break;
                case 2:
                    /*code*/
                    do
                    {
                        Console.WriteLine("Inserire il codice o la targa dell'auto da eliminare:");
                    } while (string.IsNullOrEmpty(stringa = Console.ReadLine()));
                    flotta.Elimina(stringa);
                    break;
                case 3:
                    /*code*/
                    do
                    {
                        Console.WriteLine("Inserire il codice o la targa dell'auto da visualizzare:");
                    } while (string.IsNullOrEmpty(stringa = Console.ReadLine()));
                    Console.Clear();
                    flotta.VisualizzaAuto(stringa);
                    break;
                case 4:
                    /*code*/
                    int numero = Menu(Enum.GetNames(typeof(NumeroPosti)), "Inserire il numero di posti auto da ricercare:");
                    flotta.RicercaPosti(numero);
                    break;
                case 5:
                    /*code*/
                    flotta.SalvaLog(path);
                    Console.WriteLine(path);
                    break;
            }
            Console.ReadLine();
        }
    }
}
