using System;

namespace GiocoDelLotto
{
    internal class Program
    {
        enum ruote
        {
            Bari, Cagliari, Firenze, Genova, Milano, Napoli, Palermo, Roma, Torino, Venezia, Nazionale
        }
        enum indovinati
        {
            Niente, Ambata, Ambo, Terna, Quaterna, Cinquina
        }
        static void Main(string[] args)
        {
            //Gioco del Lotto 
            int num, cont = 0, opzione, giocata, vincita = 0;
            float puntata;
            const int max = 5, maxRuote = 10;
            bool presente = false;
            int[] premi = new int[] { 2, 5, 10, 20, 50 };
            int[] ruota = new int[max];
            int[] ruotaGiocata = new int[max];
            Random casuale = new Random();

            do
            {
                Console.WriteLine("Scegli una ruota:");
                for (int i = 0; i <= maxRuote; i++)
                {
                    Console.WriteLine($"[{i}]" + (ruote)i);
                }
                opzione = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (opzione > maxRuote || opzione < 0);
            do
            {
                num = casuale.Next(1, 91);
                for (int i = 0; i < cont && !presente; i++)
                {
                    presente = num == ruota[i];
                }
                if (!presente)
                {
                    ruota[cont] = num;
                    cont++;
                }
                presente = false;
            } while (cont < max);
            cont = 0;
            do
            {
                Console.WriteLine("Inserisci la puntata");
                puntata = float.Parse(Console.ReadLine());
            } while (puntata < 0);
            do
            {
                Console.WriteLine("Inserisci numero (range tra 1 e 90)");
                giocata = int.Parse(Console.ReadLine());
                if (giocata < 1 || giocata > 90)
                {
                    Console.Write("Numero fuori da range. Premi invio per continuare ");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = 0; i < cont && !presente; i++)
                    {
                        presente = giocata == ruotaGiocata[i];
                    }
                    if (!presente)
                    {
                        ruotaGiocata[cont] = giocata;
                        cont++;
                    }
                    else
                    {
                        Console.Write("Numero già inserito. Premi invio per inserire un altro numero ");
                        Console.ReadLine();
                        presente = false;
                    }
                }
            } while (cont < max);
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (ruotaGiocata[i] == ruota[j])
                    {
                        vincita++;
                    }
                }
            }
            Console.WriteLine("Ruota {0}, numeri estratti:", (ruote)opzione);
            foreach (int stampa in ruota)
            {
                Console.WriteLine(stampa);
            }
            Console.WriteLine((indovinati)vincita);
            if (vincita != 0)
            {
                Console.WriteLine("La tua vincita è di {0} euro", puntata * premi[vincita++]);
            }
            Console.ReadLine();
        }
    }
}
