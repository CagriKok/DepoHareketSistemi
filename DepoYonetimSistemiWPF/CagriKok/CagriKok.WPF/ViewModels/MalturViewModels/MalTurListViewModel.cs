using CagriKok.IsKatmani.Manager;
using CagriKok.WPF.Commons;
using CagriKok.WPF.ViewModels.BaseViewModel;
using CagriKok.WPF.Views.MalTurViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CagriKok.WPF.ViewModels.MalturViewModels
{
    public class MalTurListViewModel : BaseView
    {
        private readonly MalTurManager malTurManager;
        private ObservableCollection<MalTurViewModel> _items;
        private MalTurViewModel _selectedItem;

        public ObservableCollection<MalTurViewModel> Items
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
        public MalTurViewModel SelectedItem
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


        public MalTurListViewModel()
        {
            malTurManager = new MalTurManager();
            RefreshCommand = new RelayCommand(o => { onRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { onInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { onDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { onUpdate(); }, o => { return _selectedItem != null; });

            onRefresh();
        }

        private void onRefresh()
        {
            var items = malTurManager.Listele();
            Items = new ObservableCollection<MalTurViewModel>();
            foreach (var item in items)
            {
                Items.Add(new MalTurViewModel(item));
            }
        }
        private void onInsert()
        {
            MalTurViewModel vm = new MalTurViewModel();
            MalTurView malTurWindow = new MalTurView
            {
                Title = "Mal Türü Ekle",
                DataContext = vm,
            };
            if (malTurWindow.ShowDialog() == true)
            {
                var item = malTurManager.Ekle(vm.MalTur);
                Items.Add(new MalTurViewModel(item));
            }
        }
        private void onDelete()
        {
            if (MessageBox.Show(_selectedItem.Ad + " adlı Mal türünü silmek istiyor musunuz?", "Mal Türü Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                malTurManager.Sil(_selectedItem.Id);
                Items.Remove(_selectedItem);
            }
        }
        private void onUpdate()
        {
            MalTurView view = new MalTurView
            {
                Title = "Mal Türü Güncelle",
                DataContext = _selectedItem,
            };
            if (view.ShowDialog() == true)
            {
                var item = malTurManager.Guncelle(_selectedItem.MalTur);
            }
        }
    }
}
