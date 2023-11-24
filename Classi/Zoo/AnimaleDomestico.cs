using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class AnimaleDomestico
    {
        string specie;
        string razza;
        string cibo;
        string verso;
        int quantita;
        mangiato mangiato;

        // metodi

        // costruttore
        public AnimaleDomestico()
        {
        }

        public void GetSpecie(string specie)
        {
            this.specie = specie;
        }
        public string SetSpecie()
        {
            return this.specie;
        }
        public void GetRazza(string razza)
        {
            this.razza = razza;
        }
        public string SetRazza()
        {
            return this.razza;
        }
        public void GetCibo(string cibo)
        {
            this.cibo = cibo;
        }
        public string SetCibo()
        {
            return this.cibo;
        }
        public void GetVerso(string verso)
        {
            this.verso = verso;
        }
        public string SetVerso()
        {
            return this.verso;
        }
        public void GetQuantita(int quantita)
        {
            this.quantita = quantita;
        }
        public int SetQuantita()
        {
            return this.quantita;
        }
        public void GetMangiato(mangiato mangiato)
        {
            this.mangiato = mangiato;
        }
        public mangiato SetMangiato()
        {
            return this.mangiato;
        }

    }
}
