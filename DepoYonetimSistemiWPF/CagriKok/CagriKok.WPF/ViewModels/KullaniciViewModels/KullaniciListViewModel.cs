using CagriKok.IsKatmani.Manager;
using CagriKok.VeriKatmani.Repositories.Abstract;
using CagriKok.WPF.Commons;
using CagriKok.WPF.ViewModels.BaseViewModel;
using CagriKok.WPF.ViewModels.DepoViewModels;
using CagriKok.WPF.Views.KullaniciViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CagriKok.WPF.ViewModels.KullaniciViewModels
{
    public class KullaniciListViewModel : BaseView
    {
        private readonly KullaniciManager kullaniciManager;
        private ObservableCollection<KullaniciViewModel> _items;
        private KullaniciViewModel _selectedItem;

        public ObservableCollection<KullaniciViewModel> Items
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

        public KullaniciViewModel SelectedItem
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


        public KullaniciListViewModel()
        {
            kullaniciManager = new KullaniciManager();
            RefreshCommand = new RelayCommand(o => { onRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { onInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { onDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { onUpdate(); }, o => { return _selectedItem != null; });

            onRefresh();
        }

        private void onRefresh()
        {
            var items = kullaniciManager.Listele();
            Items = new ObservableCollection<KullaniciViewModel>();
            foreach (var item in items)
            {
                Items.Add(new KullaniciViewModel(item));
            }
        }
        private void onInsert()
        {
            KullaniciViewModel vm = new KullaniciViewModel();
            KullaniciView view = new KullaniciView
            {
                Title = "Kullanıcı Ekle",
                DataContext = vm,
            };
            if (view.ShowDialog() == true)
            {
                var item = kullaniciManager.Ekle(vm.Kullanici);
                Items.Add(new KullaniciViewModel(item));
            }
        }
        private void onDelete()
        {
            if (MessageBox.Show(_selectedItem.Ad + " adlı Kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                kullaniciManager.Sil(_selectedItem.Id);
                Items.Remove(_selectedItem);
            }
        }
        private void onUpdate()
        {
            KullaniciView view = new KullaniciView
            {
                Title = "Kullanıcı Güncelle",
                DataContext = _selectedItem,
            };
            if (view.ShowDialog() == true)
            {
                var item = kullaniciManager.Guncelle(_selectedItem.Kullanici);
            }
        }
    }
}
