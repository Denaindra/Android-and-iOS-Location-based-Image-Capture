using System;
using static XamarinKit.Constant.Enums;

namespace XamarinKit.ViewModels
{
    public class CustomPageViewModel : BaseViewModel
    {
        public string entryItem { get; set; }
        private string title { get; set; }

        public CustomPageViewModel()
        {

        }

        public String EntryText
        {
            get
            {
                return entryItem;
            }
            set
            {
                entryItem = value;
                NotifyPropertyChanged(nameof(EntryText));
            }
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public void SetpageTitle(PopUpPage page)
        {
            if (page.Equals(PopUpPage.Group))
            {
                Title = "Enter New Group Name";
            }
            else 
            {
                Title = "Enter New Item Name";
            }
        }
    }
}
