using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoFlotta
{
    internal class Flotta
    {
        List<Auto> parcoMacchine;
        string nome;
        string autorizzazione;

        // Costruttore
        public Flotta(string nome)
        {
            this.nome = nome;
            parcoMacchine = new List<Auto>();
            autorizzazione = Ministero.Autorizzazione;
        }

        // Metodi e Proprietà
        public string Nome
        {
            get { return this.nome; }
        }
        public string Autorizzazione
        {
            get { return autorizzazione; }
        }
        public List<Auto> ParcoMacchine
        {
            set { parcoMacchine = value; }
            get { return parcoMacchine; }
        }
        public void Stampa()
        {
            Console.WriteLine($"nome flotta: {nome,10}, autorizzazione: {autorizzazione,10}");
            if (parcoMacchine.Count != 0)
            {
                parcoMacchine.ForEach(e => Console.WriteLine(e.ToString()));
            }
            else
            {
                Console.WriteLine("La flotta è vuota");
            }
        }
        public void Aggiungi(string marca, string modello, NumeroPosti posti)
        {
            parcoMacchine.Add(new Auto(marca, modello, posti));
        }
        public void Elimina(string stringa)
        {
            if (parcoMacchine.Count != 0)
            {
                parcoMacchine.RemoveAll(e => e.Codice.ToString() == stringa || e.Targa == stringa);
            }
            else
            {
                Console.WriteLine("La flotta è vuota");
            }
        }
        public void VisualizzaAuto(string stringa)
        {
            List<Auto> temp;
            if (parcoMacchine.Count != 0)
            {
                temp = parcoMacchine.FindAll(e => e.Codice.ToString() == stringa || e.Targa == stringa);
                if (temp.Count == 0)
                {
                    Console.WriteLine("Nessuna corrispondenza");
                }
                else
                {
                    temp.ForEach(e => Console.WriteLine(e.ToString()));
                }
            }
            else
            {
                Console.WriteLine("La flotta è vuota");
            }
        }
        public void RicercaPosti(int numero)
        {
            List<Auto> temp;
            parcoMacchine.FindAll(e => e.Posti == (NumeroPosti)numero);
            if (parcoMacchine.Count != 0)
            {
                temp = parcoMacchine.FindAll(e => e.Posti == (NumeroPosti)numero);
                if (temp.Count == 0)
                {
                    Console.WriteLine("Nessuna corrispondenza");
                }
                else
                {
                    temp.ForEach(e => Console.WriteLine(e.ToString()));
                }
            }
            else
            {
                Console.WriteLine("La flotta è vuota");
            }
        }
        public void SalvaLog(string path)
        {
            StreamWriter file = new StreamWriter(path, true); // stampa in coda
            file.WriteLine(DateTime.Now);
            foreach (Auto item in parcoMacchine)
            {
                file.WriteLine(item.ToString());
            }
            file.WriteLine("===========================================================");
            file.Close();
        }
    }
}
