using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EierfarmUi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = new Huhn();

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is IEiLeger gefluegel) // SafeCast inkl. null-Prüfung
            {
                gefluegel.EiLegen();
            }
            
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            IEiLeger gefluegel = cbxTiere.SelectedItem as IEiLeger; // SafeCast - liefert null (Nothing), wenn Cast fehlschlägt
            if (gefluegel != null) // IsNot Nothing
            {
                gefluegel.Fressen();
            }
        }

        private void btnNeuesSchnabeltier_Click(object sender, RoutedEventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTiere.Items.Add(schnabeltier);
            cbxTiere.SelectedItem = schnabeltier;
        }
    }
}
