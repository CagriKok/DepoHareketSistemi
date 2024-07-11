using CagriKok.IsKatmani.Manager;
using CagriKok.VarlikKatmani.Models;
using CagriKok.VarlikKatmani.Models.Enums;
using CagriKok.WPF.Commons;
using CagriKok.WPF.ViewModels.BaseViewModel;
using CagriKok.WPF.ViewModels.DepoViewModels;
using CagriKok.WPF.Views.DepoViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CagriKok.WPF.ViewModels.KullaniciViewModels
{
    public class KullaniciViewModel :BaseView
    {
        private Kullanici _kullanici;
        public Kullanici Kullanici { get { return _kullanici; } }
        public int Id
        {
            get { return _kullanici.Id; }
            set
            {
                if (_kullanici.Id != value)
                {
                    _kullanici.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _kullanici.Ad; }
            set
            {
                if (_kullanici.Ad != value)
                {
                    _kullanici.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Soyad
        {
            get { return _kullanici.Soyad; }
            set
            {
                if (_kullanici.Soyad != value)
                {
                    _kullanici.Soyad = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AdSoyad
        {
            get { return _kullanici.AdSoyad; }
            set
            {
                if (_kullanici.AdSoyad != value)
                {
                    _kullanici.Soyad = value;
                    OnPropertyChanged();
                }
            }
        }


        public string EPosta
        {
            get { return _kullanici.EPosta; }
            set
            {
                if (_kullanici.EPosta != value)
                {
                    _kullanici.EPosta = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Parola
        {
            get { return _kullanici.Parola; }
            set
            {
                if (_kullanici.Parola != value)
                {
                    _kullanici.Parola = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ParolaTekrar
        {
            get { return _kullanici.ParolaTekrar; }
            set
            {
                if (_kullanici.ParolaTekrar != value)
                {
                    _kullanici.ParolaTekrar = value;
                    OnPropertyChanged();
                }
            }
        }

        public Yetki Yetkiler
        {
            get { return _kullanici.Yetkiler; }
            set
            {
                if (_kullanici.Yetkiler != value)
                {
                    _kullanici.Yetkiler = value;
                    OnPropertyChanged();
                }
            }
        }
        public KullaniciViewModel() : this(new Kullanici()) { }

        public KullaniciViewModel(Kullanici item)
          =>  this._kullanici = item;
    }
}
