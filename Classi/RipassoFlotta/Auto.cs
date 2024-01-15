using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoFlotta
{
    internal class Auto
    {
        string marca;
        string modello;
        static int nCodice = -1;
        int codice;
        string targa;
        NumeroPosti posti;

        // Costruttore
        public Auto(string marca, string modello, NumeroPosti posti)
        {
            this.marca = marca;
            this.modello = modello;
            this.posti = posti;
            targa = Ministero.Targa;
            codice = ++nCodice;
        }

        // Metodi e Proprietà
        public string Marca
        {
            set { marca = value; }
            get { return marca; }
        }
        public string Modello
        {
            set { modello = value; }
            get { return modello; }
        }
        public NumeroPosti Posti
        {
            set { posti = value; }
            get { return posti; }
        }
        public static int NCodice
        {
            set { nCodice = value; }
            get { return nCodice; }
        }
        public int Codice
        {
            set { codice = value; }
            get { return codice; }
        }
        public string Targa
        {
            get { return targa; }
        }
        public override string ToString()
        {
            return string.Format($"marca: {marca, 10}, modello: {modello, 10}, codice: {codice, 5},\n" +
                $"targa: {targa, 10}, posti auto: {posti, 5}");
        }
    }
}
