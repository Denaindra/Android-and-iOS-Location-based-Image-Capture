using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinKit.Models.SQLDB;
using static XamarinKit.ViewModels.ItemsViewModel;

namespace XamarinKit.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public string name;
        public string sereialNumber;
        public string selectedType;
        public double latitude;
        public double logitude;
        public List<ItemType> itemList;
        public List<string> pickerList;
        public string pickerSelectedItem;
        public ImageSource phote;

        public NewItemViewModel()
        {
            ItemsList = new List<ItemType>();
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

        public double Latitude
        {
            get
            {

                return latitude;
            }
            set
            {
                latitude = value;
                NotifyPropertyChanged(nameof(Latitude));

            }
        }

        public void LoadSelectedItemDetails()
        {
            var selectedItem = App.Database.GetItem(rootViewModel.ID);

            Name = selectedItem.Name;
            PickerSelectedItem = selectedItem.ItemType;
            SereialNumber = selectedItem.SerialNo;
            PhotoSource = ImageSource.FromStream(() => new MemoryStream(selectedItem.Photo));
            //var latitdeu = selectedItem.Latitude;
            //var logitude =selectedItem.Logitude;

        }

        public void UpdateItem(MediaFile mediaFile)
        {
            indicator.StartIndicator();
            var item = new Item();
            item.ID = rootViewModel.ID;
            item.Name = Name;
            item.ItemType = pickerSelectedItem;
            item.SerialNo = SereialNumber;
            if (mediaFile != null)
            {
                item.Photo = ConvertToByteArray(mediaFile.GetStream());
                mediaFile.Dispose();
            }
            App.Database.UpdateItem(item);
            indicator.EndIndicator();

            navigation.PopModalAsync();

        }

        public double Logitude
        {
            get
            {

                return logitude;
            }
            set
            {
                logitude = value;
                NotifyPropertyChanged(nameof(Logitude));

            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }


        public List<ItemType> ItemsList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
                NotifyPropertyChanged(nameof(ItemsList));

            }
        }

        public List<string> PickerList
        {
            get
            {
                return pickerList;
            }
            set
            {
                pickerList = value;
                NotifyPropertyChanged(nameof(PickerList));

            }
        }

        public string PickerSelectedItem
        {
            get
            {
                return pickerSelectedItem;
            }
            set
            {
                pickerSelectedItem = value;
                NotifyPropertyChanged(nameof(PickerSelectedItem));
            }


        }

        public string SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                NotifyPropertyChanged(nameof(SelectedType));
            }
        }

        public string SereialNumber
        {
            get
            {
                return sereialNumber;
            }
            set
            {
                sereialNumber = value;
                NotifyPropertyChanged(nameof(SereialNumber));
            }
        }

        public void GetTypesList()
        {
            if (!ItemsList.Any())
            {
                ItemsList = App.Database.GetItemTypes().ToList();
            }

            PickerList = ItemsList.Select(t => t.TypeName).ToList();
        }



        public void SaveNewItem(MediaFile mediaFile)
        {
            indicator.StartIndicator();
            var bytes = ConvertToByteArray(mediaFile.GetStream());
            var itemType = new Item
            {
                Name = Name,
                ItemType = PickerSelectedItem,
                Latitude = Latitude,
                Logitude = Logitude,
                SerialNo = SereialNumber,
                Group = rootViewModel.Group,
                Photo = bytes,
                Storage = null
            };
            App.Database.AddItem(itemType);
            mediaFile.Dispose();
            indicator.EndIndicator();

            navigation.PopModalAsync();
        }

        public Map GetMap()
        {
            var map = new Map(
         MapSpan.FromCenterAndRadius(
        new Position(Latitude, Logitude), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 150,
                WidthRequest = 150,
            };

            return map;
        }

        public Pin SetLocationPin()
        {
            var ping = new Pin
            {
                Type = PinType.SavedPin,
                Position = new Position(Latitude, Logitude),
                Label = string.Empty
            };

            return ping;
        }

        public async Task GetCurrentPosition()
        {
            indicator.StartIndicator();

            var permission = await geoLocationUtility.CheckPermissions(Permission.Location);

            if (permission)
            {
                var GeoLocation = await geoLocationUtility.GetLoation();
                if (GeoLocation.Item2)
                {
                    Latitude = GeoLocation.Item1.Latitude;
                    Logitude = GeoLocation.Item1.Longitude;
                    indicator.EndIndicator();

                }
                else
                {
                    indicator.EndIndicator();
                    await DisplayPermission();
                }

            }
            else
            {
                indicator.EndIndicator();

                await DisplayPermission();
            }

        }

        public async Task DisplayPermission()
        {

            await Application.Current?.MainPage?.DisplayAlert("Permission", "Please Enable your Phone Location services", "Ok");

            //if(result)
            //{
            await navigation.PopModalAsync();
            //}
        }

        public void NavigateToBack()
        {
            navigation.PopModalAsync();
        }

    }
}
