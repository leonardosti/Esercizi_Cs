using System;

namespace AgendaTelefonica
{
    internal class Program
    {
        const int maxContatti = 3;
        struct Agenda
        {
            public string nome;
            public string cognome;
            public string telefono;
        }
        static void Main(string[] args)
        {
            //Esercizio AgendaTelefonica con struct e metodi
            Agenda[] rubrica = new Agenda[maxContatti];
            int opzione, i = 0;
            const int max = 7;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Agenda Telefonica");
                    Console.WriteLine("[1] Inserimento");
                    Console.WriteLine("[2] Visualizza agenda");
                    Console.WriteLine("[3] Ricerca");
                    Console.WriteLine("[4] Cancellazione");
                    Console.WriteLine("[5] Modifica");
                    Console.WriteLine("[6] Espandi");
                    Console.WriteLine("[7] Esci");
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
                        Ricerca(rubrica, ref i);
                        break;
                    case 4:
                        Cancellazione(rubrica, ref i);//to do
                        break;
                    case 5:
                        Modifica(rubrica, ref i);
                        break;
                    case 6:
                        Espandi(ref rubrica, ref i);
                        break;
                }
            } while (opzione != max);
        }
        // Definizione: Inserire il nome, cognome e telefono del contatto
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: contatore i per riferimento
        static void Inserimento(Agenda[] rubrica, ref int i)
        {
            if (i != rubrica.Length)
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
            }
            else
            {
                Console.WriteLine("Hai inserito il numero massimo di contatti");
            }
            Console.ReadLine();
        }
        // Definizione: stampare a video l'array rubrica 
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: void
        static void Visualizza(Agenda[] rubrica, ref int i)
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
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        // Definizione: Cercare se un contatto è presente o meno nella rubrica
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: void
        static void Ricerca(Agenda[] rubrica, ref int i)
        {
            string cerca;
            bool trovato = false;
            if (i != 0)
            {
                do
                {
                    Console.WriteLine("Inserisci nome e cognome del contatto da cercare");
                    cerca = Console.ReadLine();
                } while (string.IsNullOrEmpty(cerca));
                for (int j = 0; j < i && !trovato; j++)
                {
                    if (rubrica[j].nome + ' ' + rubrica[j].cognome == cerca)
                    {
                        Console.WriteLine("Contatto presente nella rubrica, il suo numero di telefono è {0}", rubrica[j].telefono);
                        Console.ReadLine();
                        trovato = true;

                    }
                }
                if (!trovato)
                {
                    Console.WriteLine("Contatto non presente nella rubrica");
                }
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        // Definizione: Cancellare contatto se presente
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: void
        static void Cancellazione(Agenda[] rubrica, ref int i)
        {
            if (i != 0)
            {
                //to do
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        // Definizione: Modificare un contatto se presente
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: void
        static void Modifica(Agenda[] rubrica, ref int i)
        {
            string modifica;
            bool trovato = false;
            if (i != 0)
            {
                do
                {
                    Console.WriteLine("Inserisci il nome e cognome del contatto");
                    modifica = Console.ReadLine().ToLower();
                } while (string.IsNullOrEmpty(modifica));
                for (int j = 0; j < i && !trovato; j++)
                {
                    if (modifica == rubrica[j].nome + ' ' + rubrica[j].cognome)
                    {
                        do
                        {
                            Console.WriteLine("Cosa vuoi modificare? (nome/cognome/telefono)");
                            modifica = Console.ReadLine().ToLower();
                        } while (string.IsNullOrEmpty(modifica));
                        switch (modifica)
                        {
                            case "nome":
                                do
                                {
                                    Console.WriteLine("Inserisci nome contatto");
                                    rubrica[j].nome = Console.ReadLine();
                                } while (string.IsNullOrEmpty(rubrica[j].nome));
                                break;
                            case "cognome":
                                do
                                {
                                    Console.WriteLine("Inserisci cognome contatto");
                                    rubrica[j].cognome = Console.ReadLine();
                                } while (string.IsNullOrEmpty(rubrica[j].cognome));
                                break;
                            case "telefono":
                                do
                                {
                                    Console.WriteLine("Inserisci numero contatto");
                                    rubrica[j].telefono = Console.ReadLine();
                                } while (rubrica[j].telefono.Length < 10 || rubrica[j].telefono.Length > 10);
                                break;
                            default:
                                Console.WriteLine("Modifca non valida");
                                break;
                        }
                        trovato = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Non hai inserito nessun contatto");
            }
            Console.ReadLine();
        }
        // Definizione: Espandere la lunghezza della rubrica 
        // Parametri:
        // Input: array rubrica e contatore i 
        // Output: array rubrica per riferimento
        static void Espandi(ref Agenda[] rubrica, ref int i)
        {
            int n;
            if (i == maxContatti)
            {
                do
                {
                    Console.WriteLine("Di quanto vuoi espandere la rubrica?");
                    n = int.Parse(Console.ReadLine());
                } while (n <= 0);
                Agenda[] espanso = new Agenda[rubrica.Length + n];
                Array.Copy(rubrica, espanso, rubrica.Length);
                rubrica = espanso;
            }
            else
            {
                Console.WriteLine("Per espandere la rubrica devi prima completarla tutta");
            }
            Console.ReadLine();
        }
    }
}
