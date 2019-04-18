using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using XamarinKit.Models.SQLDB;

namespace XamarinKit.ViewModels
{
    public class AddNewItemViewModel:BaseViewModel
    {

        private string itemName;
        private string specification;
        private ImageSource phote;

        public AddNewItemViewModel()
        {

        }

        public ImageSource PhotoSource
        {
            get
            {
                return phote;
            }
            set
            {
                phote = value;
                NotifyPropertyChanged(nameof(PhotoSource));
            }
        }


        public void GetItemTypeDetails()
        {
           var selectedItem =  App.Database.GetItemType(rootViewModel.ID);
            ItemName = selectedItem.TypeName;
            Specification = selectedItem.TypeSpec;
            PhotoSource = ImageSource.FromStream(() => new MemoryStream(selectedItem.TypePhoto));
        }

        public string ItemName
        {
            get {
                return itemName;
            }
            set 
            {
                itemName = value;
                NotifyPropertyChanged(nameof(ItemName));
            }
        }

        public string Specification
        {
            get
            {
                return specification;
            }
            set
            {
                specification = value;
                NotifyPropertyChanged(nameof(Specification));
            }
        }


        public void UpdateItemType(MediaFile mediaFile)
        {
            indicator.StartIndicator();
            var itemType = new ItemType();
            itemType.TypeName = ItemName;
            itemType.TypeSpec = Specification;
            itemType.ID = rootViewModel.ID;
            if(mediaFile != null)
            { 
              itemType.TypePhoto = ConvertToByteArray(mediaFile.GetStream());
                mediaFile.Dispose();
            }
            App.Database.UpdateItemTypes(itemType);
            indicator.EndIndicator();

           // var itesTypes = App.Database.GetItemTypes();
            NavigationBack();

        }

        public void SaveItemTypeInfo(MediaFile mediaFile)
        {
            indicator.StartIndicator();
            var bytes = ConvertToByteArray(mediaFile.GetStream());
            var itemType = new ItemType { TypeName=ItemName,TypeSpec = Specification,TypePhoto = bytes };
            App.Database.AddItemType(itemType);
            mediaFile.Dispose();
            indicator.EndIndicator();
            NavigationBack();
        }

        public void NavigationBack()
        {
            navigation.PopModalAsync();
        }

    }
}
