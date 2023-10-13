
using System;

namespace Anagrafe
{
    internal class Program
    {
        const int min = 1;
        enum Sesso
        {
            Maschio, Femmina
        }
        enum StatoCivile
        {
            Celibe, Nubile, Coniugato, Divorziato, Separato
        }
        struct Anagrafe
        {
            public string nome;
            public string cognome;
            public DateTime data;
            public string cF;
            public Sesso sesso;
            public StatoCivile statoCivile;
            public override string ToString()
            {
                return string.Format($"Nome: {nome,5}, Cognome: {cognome,5}, Data: {data.ToShortDateString(),10},\n" +
                    $"Codice Fiscale: {cF,16}, Sesso: {sesso,10}, Stato Civile: {statoCivile,10}\n" +
                    $"============================================");
            }
        }

        static void Main(string[] args)
        {
            int scelta, cnt = 0;
            string intestazione = "COMUNE";
            string[] opzioni = { "Inserisci", "Visualizza", "Modifica", "Eta'", "Elimina", "Esci" };
            Anagrafe[] cittadini = new Anagrafe[3];

            do
            {
                scelta = Menu(opzioni, intestazione);
                Console.Clear();
                if (scelta == -1)
                {
                    Errore("Errore nella scelta");
                    Console.ReadLine();
                }
                else
                {
                    switch (scelta)
                    {
                        case 1:
                            if (cnt < cittadini.Length)
                            {
                                Inserisci(cittadini, ref cnt);
                            }
                            else
                            {
                                Errore("Comune al completo");
                                Console.ReadLine();
                            }
                            break;
                        case 2:
                            if (cnt == 0)
                            {
                                Errore("Comune vuoto");
                                Console.ReadLine();
                            }
                            else
                            {
                                Visualizza(cittadini, cnt);
                            }
                            break;
                        case 3:
                            if (cnt == 0)
                            {
                                Errore("Comune vuoto");
                                Console.ReadLine();
                            }
                            else
                            {
                                Modifica(cittadini, cnt);
                            }
                            break;
                        case 4:
                            if (cnt == 0)
                            {
                                Errore("Comune vuoto");
                                Console.ReadLine();
                            }
                            else
                            {
                                int indice = RicercaCF(cittadini, cnt);
                                if (indice == -1)
                                {
                                    Errore("Persona non trovata");
                                    Console.WriteLine("Premi invio per continuare");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Eta(cittadini[indice].data);
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 5:
                            if (cnt == 0)
                            {
                                Errore("Comune vuoto");
                                Console.ReadLine();
                            }
                            else
                            {
                                int indice = RicercaCF(cittadini, cnt);
                                if (indice == -1)
                                {
                                    Errore("Persona non trovata");
                                    Console.WriteLine("Premi invio per continuare");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Elimina(cittadini, ref cnt);
                                    Console.ReadLine();
                                }
                            }
                            break;
                    }
                }
                Console.Clear();
            } while (scelta != opzioni.Length);
        }
        static int Menu(string[] opzioni, string intestazione)
        {
            int scelta = 0;

            Console.WriteLine(intestazione);
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {opzioni[i]}");
            }
            if (int.TryParse(Console.ReadLine(), out scelta) && scelta <= opzioni.Length && scelta >= min)
            {
                return scelta;
            }
            else
            {
                return -1;
            }
        }
        static void Inserisci(Anagrafe[] cittadini, ref int cnt)
        {
            int scelta = 0;
            bool doppione = false;

            Console.WriteLine("Inserire il nome:");
            while (ControlloStringhe(Console.ReadLine().ToLower(), ref cittadini[cnt].nome))
            {
                Errore("Nome non valido");
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Inserire il cognome:");
            while (ControlloStringhe(Console.ReadLine().ToLower(), ref cittadini[cnt].cognome))
            {
                Errore("Cognome non valido");
            }
            Console.WriteLine("============================================");
            Console.WriteLine("Inserire la data di nascita:");
            while (!DateTime.TryParse(Console.ReadLine(), out cittadini[cnt].data))
            {
                Errore("Data non valida");
            }
            Console.WriteLine("============================================");
            do
            {
                doppione = false;
                Console.WriteLine("Inserire il codice fiscale:");
                while (ControlloCF(Console.ReadLine(), ref cittadini[cnt].cF))
                {
                    Errore("Codice Fiscale non valido");
                }
                for (int i = 0; i < cnt; i++)
                {
                    for (int j = 0; j <= cnt; j++)
                    {
                        if (cittadini[i].cF == cittadini[j].cF && i != j)
                        {
                            doppione = true;
                            Errore("Codice Fiscale già presente");
                            break;
                        }
                    }
                }
            } while (doppione);
            Console.WriteLine("============================================");
            do
            {
                scelta = Menu(Enum.GetNames(typeof(Sesso)), "SESSO");
                if (scelta == -1)
                {
                    Errore("Errore nella scelta");
                }
                else
                {
                    cittadini[cnt].sesso = (Sesso)scelta - 1;
                }
            } while (scelta == -1);
            Console.WriteLine("============================================");
            do
            {
                scelta = Menu(Enum.GetNames(typeof(StatoCivile)), "STATO CIVILE");
                if (scelta == -1)
                {
                    Errore("Errore nella scelta");
                }
                else
                {
                    cittadini[cnt].statoCivile = (StatoCivile)scelta - 1;
                }
            } while (scelta == -1);
            cnt++;
        }
        static void Visualizza(Anagrafe[] cittadini, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine(cittadini[i].ToString());
            }
            Console.ReadLine();
        }
        static void Modifica(Anagrafe[] cittadini, int cnt)
        {
            int scelta = 0, indice = 0;

            indice = RicercaCF(cittadini, cnt);
            do
            {
                if (indice == -1)
                {
                    Errore("Persona non trovata");
                    Console.WriteLine("Premi invio per continuare");
                    Console.ReadLine();
                }
                else
                {
                    scelta = Menu(Enum.GetNames(typeof(StatoCivile)), "STATO CIVILE");
                    if (scelta == -1)
                    {
                        Errore("Errore nella scelta");
                    }
                    else
                    {
                        cittadini[indice].statoCivile = (StatoCivile)scelta - 1;
                    }
                }

            } while (scelta == -1);
        }
        static void Eta(DateTime data)
        {
            TimeSpan eta = DateTime.Now - data;
            Console.WriteLine("Eta': {0}", (int)(eta.Days / 365));
        }
        static void Elimina(Anagrafe[] cittadini, ref int cnt)
        {
            for (int i = 0; i < cittadini.Length; i++)
            {
                cittadini[i] = cittadini[i + 1];
            }
            cnt--;
        }
        static int RicercaCF(Anagrafe[] cittadini, int cnt)
        {
            string CF = "";
            int indice = 0;
            bool trovata = false;

            Console.WriteLine("Inserire il Codice Fiscale della persona da ricercare");
            while (ControlloCF(Console.ReadLine(), ref CF))
            {
                Errore("Codice Fiscale non valido");
            }
            for (int i = 0; i < cnt; i++)
            {
                if (CF == cittadini[i].cF)
                {
                    trovata = true;
                    indice = i;
                    break;
                }
            }
            if (!trovata)
            {
                return -1;
            }
            else
            {
                return indice;
            }
        }
        static bool ControlloStringhe(string stringa, ref string temp)
        {
            if (string.IsNullOrEmpty(stringa))
            {
                return true;
            }
            else
            {
                temp = stringa;
                return false;
            }
        }
        static bool ControlloCF(string stringa, ref string temp)
        {
            if (stringa.Length != 16)
            {
                return true;
            }
            else
            {
                temp = stringa;
                return false;
            }
        }
        static void Errore(string message)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
