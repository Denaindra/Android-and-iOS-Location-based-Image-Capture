using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinKit.Models;
using XamarinKit.Utilityies;

namespace XamarinKit.ViewModels
{
    public class ItemViewModel:BaseViewModel
    {
        private ObservableCollection<ListItem> menue;
        private ICommand navigationCommand;
        public ItemViewModel()
        {
            menue = new ObservableCollection<ListItem>();
            menue.Add(new ListItem { cellHearderTitle = "The maples > HCC > North Wing > 1001" });
            menue.Add(new ListItem { cellHearderTitle = "The maples > HCC > North Wing > 1002" });
            menue.Add(new ListItem { cellHearderTitle = "The maples > HCC > North Wing > 1003" });
            menue.Add(new ListItem { cellHearderTitle = "The maples > HCC > North Wing > 1004" });
            menue.Add(new ListItem { cellHearderTitle = "The maples > HCC > North Wing > 1005" });

        }

        private void BackNavigation(object obj)
        {
            navigation.PopModalAsync();
        }


        public ICommand NavigationCommand
        {
            get { 
                if (navigationCommand == null) {
                    navigationCommand = new Command(BackNavigation);
                }
                return navigationCommand; 
            
            }
        }


        public ObservableCollection<ListItem> Menue
        {
            get
            {
                return menue; 
            }
            set 
            {
                menue = value;
                NotifyPropertyChanged(nameof(Menue));
            }
        }

    }
}
