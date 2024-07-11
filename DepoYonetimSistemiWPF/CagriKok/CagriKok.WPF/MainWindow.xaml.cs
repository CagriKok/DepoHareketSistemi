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

namespace CagriKok.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSimge_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnTamEkran_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnPage1_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/DepoViews/DepoListView.xaml", UriKind.Relative);
            menuOpenCloseButton.IsChecked = false;
        }
         

        private void btnPage2_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/DepoHareketViews/DepoHareketListView.xaml", UriKind.Relative);
            menuOpenCloseButton.IsChecked = false;
        }
         

        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnPage3_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/KullaniciViews/KullaniciListView.xaml", UriKind.Relative);
            menuOpenCloseButton.IsChecked = false;
        }

        private void btnPage4_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/MalTurViews/MalTurListView.xaml", UriKind.Relative);
            menuOpenCloseButton.IsChecked = false;
        }
    }
}
