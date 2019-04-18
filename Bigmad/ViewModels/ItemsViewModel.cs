using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using XamarinKit.Models;
using XamarinKit.Models.SQLDB;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class ItemsViewModel:BaseViewModel
    {
        private ObservableCollection<UIItemType> itemtypes;
        private UIItemType itemType;


        public ItemsViewModel()
        {
            itemtypes = new ObservableCollection<UIItemType>();
        }

        public string Title
        {
            get
            {
                return string.Format("{0} {1}", "Items", rootViewModel.Group);
            }
        }

        public void LoadItemTypesPage()
        {
            indicator.StartIndicator();
            Itemtypes.Clear();
            var types = App.Database.GetItems().Where(s => s.Group.Contains(rootViewModel.Group)).ToList();

            foreach (var item in types)
            {
                var imageTypeUI = new UIItemType
                {
                    ID = item.ID,
                    TypeName = item.Name,
                    TypePhoto = ImageSource.FromStream(() => new MemoryStream(item.Photo))
                };

                Itemtypes.Add(imageTypeUI);
            }

            indicator.EndIndicator();

        }

        public void NavigateToItemPage()
        {
            navigation.PushModalAsync(new AddNewItem(rootViewModel));
        }

        public void PopUpView()
        {
            navigation.PopModalAsync();
        }

        public void SetItemTypes(object type)
        {
            itemType = ((UIItemType)type);
            rootViewModel.ID = itemType.ID;
            rootViewModel.IsEdit = true;
            NavigateToItemPage();
        }

        public void AddNewItemType()
        {

        }
        public void DeleteItem()
        {
            indicator.StartIndicator();
            App.Database.DeleteItem(itemType.ID);
            LoadItemTypesPage();
            indicator.EndIndicator();
        }
        public ObservableCollection<UIItemType> Itemtypes
        {
            get
            {
                return itemtypes;
            }
            set
            {
                itemtypes = value;
                NotifyPropertyChanged(nameof(itemtypes));
            }
        }


    }
}
