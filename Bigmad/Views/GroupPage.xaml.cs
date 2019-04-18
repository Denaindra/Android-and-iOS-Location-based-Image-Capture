using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinKit.Utilityies;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class GroupPage : ContentPage
    {
        private GroupViewModel groupViewModel;

        public GroupPage()
        {
            InitializeComponent();
            BindingContext = groupViewModel = new GroupViewModel();
            groupViewModel.navigation = Navigation;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            groupViewModel.GetGroupList();
        }

        void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            groupViewModel.SetGroupName(item);
            groupViewModel.NavigateItemPage();
        }

        void AddClicked(object sender, System.EventArgs e)
        {
            groupViewModel.NewGroupPopUp();
        }

        //void DeleteClicked(object sender, System.EventArgs e)
        //{
        //    if (!groupViewModel.IsItemGroup())
        //    {
        //        groupViewModel.DeleteID();
        //    }
        //    else
        //    {
        //        DisplayAlert("Group", "Please Selected a group Item", "OK");
        //    }
        //}

        void TypeClicked(object sender, System.EventArgs e)
        {
            groupViewModel.NavigateItemTypesPage();
        }
    }
}
