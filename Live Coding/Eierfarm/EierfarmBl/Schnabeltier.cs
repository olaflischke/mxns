using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEiLeger, INotifyPropertyChanged
    {
        public Schnabeltier()
        {
            this.Gewicht = 1000;
        }

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void EiLegen()
        {
            if (this.Gewicht > 1000)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public void Fressen()
        {
            if (this.Gewicht < 4500)
            {
                this.Gewicht += 450;
            }
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}