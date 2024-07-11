using CagriKok.VarlikKatmani.Models.Enums;
using CagriKok.VeriKatmani.Repositories.Abstract;
using CagriKok.WPF.ViewModels.DepoHareketViewModels;
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

namespace CagriKok.WPF.Views.DepoHareketViews
{
    /// <summary>
    /// Interaction logic for DepoHareketView.xaml
    /// </summary>
    public partial class DepoHareketView : Window
    {
        public DepoHareketView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtMiktar.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAciklama.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxMalTurler.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            cbxDepolar.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            cbxHareket.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            dpTarih.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();


            this.DialogResult = true;
        }
    }
}
