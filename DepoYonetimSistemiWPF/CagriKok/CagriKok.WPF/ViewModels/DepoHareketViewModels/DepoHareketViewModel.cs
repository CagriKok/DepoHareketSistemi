using CagriKok.IsKatmani.Manager;
using CagriKok.VarlikKatmani.Models;
using CagriKok.VarlikKatmani.Models.Enums;
using CagriKok.VeriKatmani;
using CagriKok.WPF.ViewModels.BaseViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CagriKok.WPF.ViewModels.DepoHareketViewModels
{
    public class DepoHareketViewModel : BaseView
    {
        private DepoHareket _depoHareket;
        private ObservableCollection<Depo> _depolar;
        private ObservableCollection<MalTur> _malturleri;

        private DepoHareketTipleri hareketTip;

        //private DepoHareketTipleri _selectedItem;
        //private ObservableCollection<DepoHareketTipleri> _depoHareketTipleri;


        //private int _selectedBirimId;
        //public int SelectedBirimId
        //{
        //    get { return _selectedBirimId; }
        //    set
        //    {
        //        if (_selectedBirimId != value)
        //        {
        //            _selectedBirimId = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        public DepoHareket DepoHareket { get { return _depoHareket; } }


        public int SelectedHareket
         {
            get { return (int)_depoHareket.HareketTipleri; }
            set
            {
                if ((int)_depoHareket.HareketTipleri != value)
                {
                    _depoHareket.HareketTipleri = (DepoHareketTipleri)value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedItem
        {
            get { return (int)_depoHareket.Birimler; }
            set
            {
                if ((int)_depoHareket.Birimler != value)
                {
                    _depoHareket.Birimler = (Birim)value;
                    OnPropertyChanged();
                }
            }
        }



        public int Id
        {
            get { return _depoHareket.Id; }
            set
            {
                if (_depoHareket.Id != value)
                {
                    _depoHareket.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Miktar
        {
            get { return _depoHareket.Miktar; }
            set
            {
                if (_depoHareket.Miktar != value)
                {
                    _depoHareket.Miktar = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime TarihSaat
        {
            get { return _depoHareket.TarihSaat; }
            set
            {
                if (_depoHareket.TarihSaat != value)
                {
                    _depoHareket.TarihSaat = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return _depoHareket.Description; }
            set
            {
                if (_depoHareket.Description != value)
                {
                    _depoHareket.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DepoId
        {
            get { return _depoHareket.DepoId; }
            set
            {
                if (_depoHareket.DepoId != value)
                {
                    _depoHareket.DepoId = value;
                    OnPropertyChanged();
                }
            }
        }
        public Depo Depo
        {
            get { return _depoHareket.Depo; }
            set
            {
                if (_depoHareket.Depo != value)
                {
                    _depoHareket.Depo = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MalTurId
        {
            get { return _depoHareket.MalTurId; }
            set
            {
                if (_depoHareket.MalTurId != value)
                {
                    _depoHareket.MalTurId = value;
                    OnPropertyChanged();
                }
            }
        }
        public MalTur MalTur
        {
            get { return _depoHareket.MalTur; }
            set
            {
                if (_depoHareket.MalTur != value)
                {
                    _depoHareket.MalTur = value;
                    OnPropertyChanged();
                }
            }
        }

        //public DepoHareketTipleri DepoHareketTipleri
        //{
        //    get { return _depoHareket.HareketTipleri; }
        //    set
        //    {
        //        if (_depoHareket.HareketTipleri != value)
        //        {
        //            _depoHareket.HareketTipleri = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //public DepoHareketTipleri SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set
        //    {
        //        if (_selectedItem != value)
        //        {
        //            _selectedItem = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}


        //public ObservableCollection<DepoHareketTipleri> DepoHareketTip
        //{
        //    get { return _depoHareketTipleri; }
        //    set
        //    {
        //        if(_depoHareketTipleri != value)
        //        {
        //            _depoHareketTipleri = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}





        //public Birim Birimler
        //{
        //    get { return _depoHareket.Birimler; }
        //    set
        //    {
        //        if (_depoHareket.Birimler != value)
        //        {
        //            _depoHareket.Birimler = value;
        //            OnPropertyChanged();
        //        }   
        //    }
        //}





        public ObservableCollection<Depo> Depolar
        {
            get { return _depolar; }
            set
            {
                if (_depolar != value)
                {
                    _depolar = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MalTur> MalTurleri
        {
            get { return _malturleri; }
            set
            {
                if (_malturleri != value)
                {
                    _malturleri = value;
                    OnPropertyChanged();
                }
            }
        }



        public DepoHareketViewModel() : this(new DepoHareket()) { }

        public DepoHareketViewModel(DepoHareket depoHareket)
        {
            //DepoHareketTipleri[] tipDizisi = (DepoHareketTipleri[])Enum.GetValues(typeof(DepoHareketTipleri));
            // = new ObservableCollection<DepoHareketTipleri>(tipDizisi);

            using (var depoManager = new DepoManager())
                Depolar = new ObservableCollection<Depo>(depoManager.Listele());

            using (var malTurManager = new MalTurManager())
                MalTurleri = new ObservableCollection<MalTur>(malTurManager.Listele());

            this._depoHareket = depoHareket;

        }
    }
}
