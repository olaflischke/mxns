using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BummlerUi
{
    public class Bummler
    {
        public string Bummeln()
        {
            double result = Wurzelsumme(1e9);
            return "Fertig mit Bummeln";
        }

        public async Task<string> BummelnAsync()
        {
            double result = await Task.Run(() => Wurzelsumme(1e9));
            return "Fertig mit Bummeln";
        }

        public string Troedeln()
        {
            double result = Wurzelsumme(2e9);
            return "Fertig mit Trödeln";
        }

        public async Task<string> TroedelnAsync()
        {
            double result = await Task.Run(() => Wurzelsumme(2e9));
            return "Fertig mit Trödeln";
        }


        private double Wurzelsumme(double maximum)
        {
            double sum = 0;

            for (double i = 0; i < maximum; i++)
            {
                sum += Math.Sqrt(i);
            }

            return sum;
        }
    }
}
