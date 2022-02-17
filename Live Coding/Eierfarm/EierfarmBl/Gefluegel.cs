using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : INotifyPropertyChanged, IEiLeger
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Gefluegel(string name)
        {
            this.Name = name;
        }

        // Auto-Property-Initilaizer
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnPropertyChanged("Gewicht");
            }
        }

        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();


        public abstract void Fressen();
        public abstract void EiLegen();
    }
}
