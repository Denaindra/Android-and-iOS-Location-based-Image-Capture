using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class ItemTypesPage : ContentPage
    {
        private ItemTypesViewModel itemTypesViewModel;

        public ItemTypesPage()
        {
            InitializeComponent();
            BindingContext = itemTypesViewModel = new ItemTypesViewModel();
            itemTypesViewModel.navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            itemTypesViewModel.LoadItemTypesPage();
        }
        void ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            itemTypesViewModel.SetItemTypes(item);
        }

        void AddClicked(object sender, System.EventArgs e)
        {
            itemTypesViewModel.NavigateToNextPage();
        }

        void DeleteClicked(object sender, System.EventArgs e)
        {
            itemTypesViewModel.DeleteItem();
        }

        void BackClicked(object sender, System.EventArgs e)
        {
            itemTypesViewModel.NavigateToBack();
        }



    }
}
