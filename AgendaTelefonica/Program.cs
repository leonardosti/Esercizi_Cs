using System;

namespace AgendaTelefonica
{
    internal class Program
    {
        const int maxContatti = 3;
        struct agenda
        {
            public string nome;
            public string cognome;
            public string telefono;
        }
        static void Main(string[] args)
        {
            //Esercizio AgendaTelefonica con struct e metodi
            agenda[] rubrica = new agenda[maxContatti];
            int opzione, i = 0;
            const int max = 4;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("====== Agenda Telefonica ======");
                    Console.WriteLine("[1] Inserimento");
                    Console.WriteLine("[2] Visualizza contatti telefonici");
                    Console.WriteLine("[3] Modifica contatto");
                    Console.WriteLine("[4] Esci");
                    opzione = Int32.Parse(Console.ReadLine());
                } while (opzione < 1 || opzione > max);
                switch (opzione)
                {
                    case 1:
                        Inserimento(rubrica, ref i);
                        break;
                    case 2:
                        Visualizza(rubrica, ref i);
                        break;
                    case 3:
                        Modifica(rubrica, ref i);
                        break;
                }
            } while (opzione != max);
        }
        // Definizione: Inserire il nome, cognome e telefono del contatto
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: array rubrica e contatore i per riferimento
        static agenda[] Inserimento(agenda[] rubrica, ref int i)
        {
            if (i != maxContatti)
            {
                Console.WriteLine("Inserisci nome contatto");
                rubrica[i].nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome contatto");
                rubrica[i].cognome = Console.ReadLine();
                do
                {
                    Console.WriteLine("Inserisci numero contatto");
                    rubrica[i].telefono = Console.ReadLine();
                } while (rubrica[i].telefono.Length < 10 || rubrica[i].telefono.Length > 10);
                i++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Hai inserito il numero massimo di contatti");
                Console.ReadLine();
            }
            return rubrica;
        }
        // Definizione: stampare a video l'array rubrica 
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: void
        static void Visualizza(agenda[] rubrica, ref int i)
        {
            if (i != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("Nome contatto");
                    Console.WriteLine(rubrica[j].nome);
                    Console.WriteLine("Cognome contatto");
                    Console.WriteLine(rubrica[j].cognome);
                    Console.WriteLine("Telefono");
                    Console.WriteLine(rubrica[j].telefono);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
                Console.ReadLine();
            }
        }
        // Definizione: modificare il telefono di un contatto se presente
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: array rubrica
        static agenda[] Modifica(agenda[] rubrica, ref int i)
        {
            string modifica;
            bool trovato = false;
            if (i != 0)
            {
                Console.WriteLine("Inserisci il nome e cognome del contatto che vuoi modifcare");
                modifica = Console.ReadLine();
                for (int j = 0; j < i && !trovato; j++)
                {
                    if (modifica == rubrica[j].nome + ' ' +rubrica[j].cognome)
                    {
                        do
                        {
                            Console.WriteLine("Inserisci numero contatto");
                            rubrica[j].telefono = Console.ReadLine();
                        } while (rubrica[j].telefono.Length < 10 || rubrica[j].telefono.Length > 10);
                        trovato = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Completare prima il punto 1");
                Console.ReadLine();
            }
            return rubrica;
        }
    }
}
