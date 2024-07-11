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
using System.Windows.Shapes;

namespace CagriKok.WPF.Views.KullaniciViews
{
    /// <summary>
    /// Interaction logic for KullaniciView.xaml
    /// </summary>
    public partial class KullaniciView : Window
    {
        public KullaniciView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEPosta.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtParola.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            rdDepoSorumlusu.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            rdAdmin.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

            this.DialogResult = true;

        }
    }
}
