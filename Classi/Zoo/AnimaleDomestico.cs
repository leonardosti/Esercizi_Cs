using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class AnimaleDomestico
    {
        string specie, razza, cibo, verso;
        int quantita;
        public override string ToString()
        {
            return string.Format($"specie: {specie,10}, razza: {razza,10}, cibo: {cibo,10}, \n" +
                $"verso: {verso,10}, quantità: {quantita,10}");
        }

        // costruttori
        public AnimaleDomestico()
        {
        }
        public AnimaleDomestico(string specie, string razza, string cibo, string verso, int quantita)
        {
            this.specie = specie;
            this.razza = razza;
            this.cibo = cibo;
            this.verso = verso;
            this.quantita = quantita;
        }

        public void SetSpecie(string specie)
        {
            this.specie = specie;
        }
        public string GetSpecie()
        {
            return this.specie;
        }
        public void SetRazza(string razza)
        {
            this.razza = razza;
        }
        public string GetRazza()
        {
            return this.razza;
        }
        public void SetCibo(string cibo)
        {
            this.cibo = cibo;
        }
        public string GetCibo()
        {
            return this.cibo;
        }
        public void SetVerso(string verso)
        {
            this.verso = verso;
        }
        public string GetVerso()
        {
            return this.verso;
        }
        public void SetQuantita(int quantita)
        {
            this.quantita = quantita;
        }
        public int GetQuantita()
        {
            return this.quantita;
        }
    }
}
