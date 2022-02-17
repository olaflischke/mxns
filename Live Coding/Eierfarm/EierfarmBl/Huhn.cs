using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    // "Huhn ist ein Gefluegel"
    public class Huhn : Gefluegel
    {
        public Huhn() : base("Neues Huhn")
        {
            this.Gewicht = 1000;
        }


        public Huhn(string name) : this() // Konstruktoren-Kaskade: Ruft parameterlosen Konstruktor auf
        {
            this.Name = name;
        }

        // Methode ohne Rückgabewert (= Sub)
        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
