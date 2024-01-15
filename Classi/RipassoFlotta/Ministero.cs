using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RipassoFlotta
{
    static internal class Ministero
    {
        public static string Targa
        {
            get { return CreaTarga(); }
        }
        public static string Autorizzazione
        {
            get { return CreaAutorizzazione(); }
        }
        public static string CreaTarga()
        {
            string Targa = "";
            Random random = new Random();
            Thread.Sleep(100);
            for (int i = 0; i < 7; i++)
            {
                if (i < 2 || i > 4) // Lettere della targa 
                {
                    Targa += (char)random.Next('A', 'Z' + 1);
                }
                else // Numeri della targa
                {
                    Targa += random.Next(0, 10);
                }
            }
            return Targa;
        }
        public static string CreaAutorizzazione()
        {
            string Autorizzazione = "", vocali = "AEIOU";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                Autorizzazione += random.Next(0, 10); // Numeri dell'autorizzazione
            }
            Autorizzazione += vocali[random.Next(0, vocali.Length)]; // Vocale dell'autorizzazione
            return Autorizzazione;
        }
    }
}
