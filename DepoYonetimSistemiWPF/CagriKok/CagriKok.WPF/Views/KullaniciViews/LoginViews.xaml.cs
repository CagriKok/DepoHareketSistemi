using CagriKok.VarlikKatmani.Models;
using CagriKok.VarlikKatmani.Models.Enums;
using CagriKok.VeriKatmani;
using CagriKok.WPF.Views.DepoHareketViews;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for LoginViews.xaml
    /// </summary>
    public partial class LoginViews : Window
    {
        private readonly UnitOfWork uow;
        public LoginViews()
        {
            InitializeComponent();
            uow = new UnitOfWork();
        }

        public Kullanici Giris(string eposta, string parola)
        {
            return uow.KullaniciRepository.Giris(eposta, parola);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string eposta = txtEposta.Text;
            string parola = txtParola.Password;

            Kullanici kullanici = Giris(eposta, parola);

            if (kullanici != null)
            {
                if (kullanici.Yetkiler == Yetki.Admin)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else if (kullanici.Yetkiler == Yetki.DepoSorumlusu)
                {
                    MainWindow2 main2 = new MainWindow2();
                    main2.Show();
                }

                lblError.Text = "";
                this.DialogResult = true;

                this.Close();
            }
            else
            {
                lblError.Text = "Kullanıcı Adı ya da parola hatalı!!!";
            }
        }



    }
}
