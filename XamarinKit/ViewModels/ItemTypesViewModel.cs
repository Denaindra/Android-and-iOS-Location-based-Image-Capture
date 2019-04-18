using System;
using System.Collections.ObjectModel;
using System.IO;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinKit.Models;
using XamarinKit.Models.SQLDB;
using XamarinKit.Views;
using static XamarinKit.Constant.Enums;

namespace XamarinKit.ViewModels
{
    public class ItemTypesViewModel : BaseViewModel
    {
        private ObservableCollection<ItemType> itemTypes;
        private ItemType itemType;
        public ItemTypesViewModel()
        {
            itemTypes = new ObservableCollection<ItemType>();

        }

        public void LoadItemTypesPage()
        {
            indicator.StartIndicator();
            Itemtypes.Clear();
            var types = App.Database.GetItemTypes();

            foreach (var item in types)
            {
                Itemtypes.Add(item);
            }
            indicator.EndIndicator();
        }

        public ItemType ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
                NotifyPropertyChanged(nameof(ItemType));
            }
        }

        public void SetItemTypes(object type)
        {
            ItemType = ((ItemType)type);
            rootViewModel.IsEdit = true;
            rootViewModel.ID = ItemType.ID;
            NavigateToNextPage();
        }

        public void NavigateToNextPage()
        {
            navigation.PushModalAsync(new AddNewItemType(rootViewModel));
        }

        public void NavigateToBack()
        {
            navigation.PopModalAsync();
        }

        public void DeleteItem()
        {
            indicator.StartIndicator();
            if (itemType != null)
            {
                App.Database.DeleteItemType(itemType.ID);
            }
            indicator.EndIndicator();
        }

        public ObservableCollection<ItemType> Itemtypes
        {
            get
            {
                return itemTypes;
            }
            set
            {
                itemTypes = value;
                NotifyPropertyChanged(nameof(Itemtypes));
            }
        }
    }
}
