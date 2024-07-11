using CagriKok.VarlikKatmani.Models;
using CagriKok.WPF.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.WPF.ViewModels.MalturViewModels
{
    public class MalTurViewModel : BaseView
    {
        private MalTur _maltur;
        public MalTur MalTur { get { return _maltur; } }

        public int Id
        {
            get { return _maltur.Id; }
            set
            {
                if (_maltur.Id != value)
                {
                    _maltur.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ad
        {
            get { return _maltur.Ad; }
            set
            {
                if (_maltur.Ad != value)
                {
                    _maltur.Ad = value;
                    OnPropertyChanged();
                }
            }
        }
        public MalTurViewModel() : this(new MalTur()) { }

        public MalTurViewModel(MalTur item)
          => this._maltur = item;
    }
}
