using CagriKok.IsKatmani.Manager;
using CagriKok.WPF.Commons;
using CagriKok.WPF.ViewModels.BaseViewModel;
using CagriKok.WPF.Views.DepoViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CagriKok.WPF.ViewModels.DepoViewModels
{
    public class DepoListViewModel : BaseView
    {
        private readonly DepoManager _depoManager;
        private ObservableCollection<DepoViewModel> _items;
        private DepoViewModel _selectedItem;

        public ObservableCollection<DepoViewModel> Items
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
        public DepoViewModel SelectedItem
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


        public DepoListViewModel()
        {
            _depoManager = new DepoManager();
            RefreshCommand = new RelayCommand(o => { onRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { onInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { onDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { onUpdate(); }, o => { return _selectedItem != null; });

            onRefresh();
        }

        private void onRefresh()
        {
            var items = _depoManager.Listele();
            Items = new ObservableCollection<DepoViewModel>();
            foreach (var item in items)
            {
                Items.Add(new DepoViewModel(item));
            }
        }
        private void onInsert()
        {
            DepoViewModel vm = new DepoViewModel();
            DepoView depoview = new DepoView
            {
                Title = "Depo Ekle",
                DataContext = vm,
            };
            if (depoview.ShowDialog() == true)
            {
                var item = _depoManager.Ekle(vm.Depo);
                Items.Add(new DepoViewModel(item));
            }
        }
        private void onDelete()
        {
            if (MessageBox.Show(_selectedItem.Ad + " adlı Depoyu silmek istiyor musunuz?", "Depo Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _depoManager.Sil(_selectedItem.Id);
                Items.Remove(_selectedItem);
            }
        }
        private void onUpdate()
        {
            DepoView view = new DepoView
            {
                Title = "Depo Güncelle",
                DataContext = _selectedItem,
            };
            if (view.ShowDialog() == true)
            {
                var item = _depoManager.Guncelle(_selectedItem.Depo);
            }
        }
    }
}
