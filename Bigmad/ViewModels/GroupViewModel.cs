using System;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Services;
using XamarinKit.Models;
using XamarinKit.Models.SQLDB;
using XamarinKit.Utilityies;
using XamarinKit.Views;
using static XamarinKit.Constant.Enums;

namespace XamarinKit.ViewModels
{
    public class GroupViewModel : BaseViewModel
    {
        private ObservableCollection<ItemGroup> groups;
        public GroupViewModel()
        {
            groups = new ObservableCollection<ItemGroup>();
        }

        public ItemGroup itemGroup;

        public ItemGroup ItemGroup
        {
            get
            {
                return itemGroup;
            }
            set
            {
                itemGroup = value;
                NotifyPropertyChanged(nameof(ItemGroup));
            }
        }


        public ObservableCollection<ItemGroup> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
                NotifyPropertyChanged(nameof(Groups));
            }
        }

        public void SetGroupName(object gorup)
        {
            ItemGroup = ((ItemGroup)gorup);
        }

        public bool IsItemGroup()
        {
            if (ItemGroup is null)
            {
                return true;
            }
            return false;
        }

        public async void NewGroupPopUp()
        {
            SetCommonView();
            await PopupNavigation.Instance.PushAsync(new CustomView(simpleDelegate, PopUpPage.Group));
        }

        public void NavigateItemTypesPage()
        {
            navigation.PushModalAsync(new ItemTypesPage());
        }

        public void NavigateItemPage()
        {
            rootViewModel.Group = ItemGroup.Name;
            navigation.PushModalAsync(new ItemsPage(rootViewModel));
        }

        public void GetGroupList()
        {
            indicator.StartIndicator();
            Groups.Clear();
            var groupList = App.Database.GetGroups();
            foreach (var group in groupList)
            {
                Groups.Add(group);
            }
            indicator.EndIndicator();
        }
        public override void AddNewGroup(string groupName)
        {
            indicator.StartIndicator();
            var NewItemGroup = new ItemGroup { Name = groupName };
            App.Database.AddItemGroup(NewItemGroup);
            GetGroupList();
            indicator.EndIndicator();
        }

        public void DeleteID()
        {
            indicator.StartIndicator();
            App.Database.DeleteGroup(ItemGroup.ID);
            GetGroupList();
            indicator.EndIndicator();
        }
    }
}
