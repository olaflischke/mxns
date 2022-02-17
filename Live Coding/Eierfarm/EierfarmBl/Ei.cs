using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Ei
    {
        public Ei(IEiLeger mutter) // Ei meinEi = new Ei();
        {
            Random random = new Random();
            this.Gewicht = random.Next(45, 81);
            //this.Farbe = (EiFarbe)random.Next(3); // DirectCast - kann Exception auslösen, falls Cast fehlschlägt
            this.Farbe = (EiFarbe)random.Next(Enum.GetValues(typeof(EiFarbe)).Length); // DirectCast - kann Exception auslösen, falls Cast fehlschlägt
            this.Mutter = mutter;
        }

        // Auto-Property
        // Property mit automatisch generiertem backing Field
        public EiFarbe Farbe { get; set; }

        public IEiLeger Mutter { get; set; }

        // Backing-Field
        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; } // var g = meinEi.Gewicht;
            set
            {
                if (value > 0)
                {
                    _gewicht = value;
                }
            } // meinEi.Gewicht = 60;
        }

    }

    public enum EiFarbe
    {
        Hell,
        Gruen,
        Dunkel
    }
}
