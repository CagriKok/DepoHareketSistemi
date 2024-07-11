using CagriKok.IsKatmani.Manager;
using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani;
using CagriKok.WPF.Commons;
using CagriKok.WPF.ViewModels.BaseViewModel;
using CagriKok.WPF.Views.DepoHareketViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CagriKok.WPF.ViewModels.DepoHareketViewModels
{
    public class DepoHareketListViewModel : BaseView
    {
        private readonly DepoHareketManager depohareketmanager;
        private ObservableCollection<DepoHareketViewModel> _items;
        private DepoHareketViewModel _selectedItem;

        public ObservableCollection<DepoHareketViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public DepoHareketViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public DepoHareketListViewModel()
        {
            depohareketmanager = new DepoHareketManager();
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { OnDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { OnUpdate(); }, o => { return _selectedItem != null; });

            OnRefresh();
        }

        private void OnRefresh()
        {
            var items = depohareketmanager.Listele();
            Items = new ObservableCollection<DepoHareketViewModel>();
            foreach (var item in items)
            {
                Items.Add(new DepoHareketViewModel(item));
            }
        }

        private void OnInsert()
        {
            DepoHareketViewModel vm = new DepoHareketViewModel();
            DepoHareketView view  = new DepoHareketView
            {
                Title = "Depo Hareket Ekle",
                DataContext = vm
            };

            if (view.ShowDialog() == true)
            {
                var item = depohareketmanager.Ekle(vm.DepoHareket);
                Items.Add(new DepoHareketViewModel(item));
            }

        }

        private void OnDelete()
        {
            if (MessageBox.Show(_selectedItem.DepoHareket.Depo.Ad + " adlı Depoyu silmek istiyor musunuz?", "Depo Hareketi Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                depohareketmanager.Sil(_selectedItem.DepoHareket.Id); 
                Items.Remove(_selectedItem);
                OnRefresh();
            }
        }

        private void OnUpdate()
        {
            DepoHareketView view = new DepoHareketView
            {
                Title = "Depo Hareketi Güncelle",
                DataContext = _selectedItem
            };

            if (view.ShowDialog() == true)
            {
                var item = depohareketmanager.Guncelle(_selectedItem.DepoHareket);
                OnRefresh();
            }
        }
    }
}
