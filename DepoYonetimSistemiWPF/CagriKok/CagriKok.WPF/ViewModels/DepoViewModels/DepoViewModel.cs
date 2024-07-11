using CagriKok.VarlikKatmani.Models;
using CagriKok.WPF.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.WPF.ViewModels.DepoViewModels
{
    public class DepoViewModel : BaseView
    {
        private Depo _depo;
        public Depo Depo { get { return _depo; } }

        public int Id
        {
            get { return _depo.Id; }
            set
            {
                if (_depo.Id != value)
                {
                    _depo.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ad
        {
            get { return _depo.Ad; }
            set
            {
                if (_depo.Ad != value)
                {
                    _depo.Ad = value;
                    OnPropertyChanged();
                }
            }
        }
        public DepoViewModel() : this(new Depo()) { }

        public DepoViewModel(Depo item)
           => this._depo = item;
    }
}
