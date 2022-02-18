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

namespace BummlerUi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler = new Bummler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnBummeln_Click(object sender, RoutedEventArgs e)
        {
            lblBummeln.Content = "";
            //lblBummeln.Content =  bummler.Bummeln();
            lblBummeln.Content = await bummler.BummelnAsync();
        }

        private async void btnTroedeln_Click(object sender, RoutedEventArgs e)
        {
            lblTrodeln.Content = "";
            //lblTrodeln.Content = bummler.Troedeln();
            lblTrodeln.Content = await bummler.TroedelnAsync();
        }
    }
}
