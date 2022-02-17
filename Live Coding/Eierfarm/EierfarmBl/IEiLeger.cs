using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEiLeger
    {
        double Gewicht { get; set; }
        ObservableCollection<Ei> Eier { get; set; }

        void Fressen();
        void EiLegen();
    }
}