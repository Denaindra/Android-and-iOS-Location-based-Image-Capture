using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class ItemsPage : ContentPage
    {
        private ItemsViewModel itemsViewModel;

        public ItemsPage(RootViewModel rootViewModel)
        {
            InitializeComponent();
            itemsViewModel = new ItemsViewModel();
            itemsViewModel.navigation = Navigation;
            itemsViewModel.rootViewModel = rootViewModel;
            BindingContext = itemsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            itemsViewModel.LoadItemTypesPage();
        }

        void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            itemsViewModel.SetItemTypes(item);
        }

        void AddClicked(object sender, System.EventArgs e)
        {
            itemsViewModel.NavigateToItemPage();
        }

        void DeleteClicked(object sender, System.EventArgs e)
        {
            itemsViewModel.DeleteItem();
        }

        void GroupClicked(object sender, System.EventArgs e)
        {
            itemsViewModel.PopUpView();
        }
    }
}
