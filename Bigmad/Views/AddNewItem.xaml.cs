using System;
using System.Collections.Generic;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinKit.ViewModels;
using static XamarinKit.ViewModels.ItemsViewModel;

namespace XamarinKit.Views
{
    public partial class AddNewItem : ContentPage
    {
        private NewItemViewModel itemTypesViewModel;
        private MediaFile mediaFile;

        public AddNewItem(RootViewModel rootViewModel)
        {
            InitializeComponent();
            itemTypesViewModel = new NewItemViewModel();
            itemTypesViewModel.rootViewModel = rootViewModel;
            BindingContext = itemTypesViewModel;
            itemTypesViewModel.navigation = Navigation;
         
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            itemTypesViewModel.GetTypesList();
            LoadMap();
            if(itemTypesViewModel.rootViewModel.IsEdit)
            {
                itemTypesViewModel.LoadSelectedItemDetails();
               
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            itemTypesViewModel.rootViewModel.IsEdit = false;

        }

        private async void LoadMap()
        {
            mapView.Children.Clear();

            await itemTypesViewModel.GetCurrentPosition();

            var mapLocation = itemTypesViewModel.GetMap();

            mapLocation.Pins.Add(itemTypesViewModel.SetLocationPin());

            mapView.Children.Add(mapLocation);
        }

        void SaveClicked(object sender, System.EventArgs e)
        {
            if (itemTypesViewModel.rootViewModel.IsEdit)
            {
                itemTypesViewModel.rootViewModel.IsEdit = false;
                itemTypesViewModel.UpdateItem(mediaFile);
            }
            else 
            {
                itemTypesViewModel.SaveNewItem(mediaFile);
            }
      
        }

        void ItemSelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker picker = sender as Picker;
            itemTypesViewModel.PickerSelectedItem = picker.SelectedItem.ToString();
        }

        void CancleClicked(object sender, System.EventArgs e)
        {
            itemTypesViewModel.NavigateToBack();
        }

        async void TakeClicked(object sender, System.EventArgs e)
        {
            if (!itemTypesViewModel.CheckCameraMediea())
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
            }
            else
            {
                mediaFile = await itemTypesViewModel.CaptureImage();
                img.Source = ImageSource.FromStream(() => mediaFile.GetStream());
            }
        }

      async void ResetClicked(object sender, System.EventArgs e)
        {
            //img.Source = null;
            //img.BackgroundColor = Color.Purple;

            if(!itemTypesViewModel.CheckImageMedia())
            {
                await DisplayAlert("No gallery support", "Permission not granted to photos.", "OK");

            }
            else 
            {
                mediaFile = await itemTypesViewModel.BrowsImage();
                img.Source = ImageSource.FromStream(() => mediaFile.GetStream());
            }
        }

        void GetGeoLocation(object sender, System.EventArgs e)
        {
            LoadMap();
        }
    }
}
