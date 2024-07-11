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

namespace CagriKok.WPF.Views.MalTurViews
{
    /// <summary>
    /// Interaction logic for MalTurView.xaml
    /// </summary>
    public partial class MalTurView : Window
    {
        public MalTurView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtMalTur.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.DialogResult = true;
        }
    }
}
