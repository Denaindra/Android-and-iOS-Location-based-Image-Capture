using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using XamarinKit.ViewModels;
using static XamarinKit.Constant.Enums;
using static XamarinKit.ViewModels.BaseViewModel;

namespace XamarinKit.Views
{
    public partial class CustomView : PopupPage
    {
        private GetGroupName simpleDelegate;
        private CustomPageViewModel customPageViewModel;

        public CustomView()
        {
            InitializeComponent();
        }

        public CustomView(GetGroupName simpleDelegate,PopUpPage page)
        {
            InitializeComponent();
            BindingContext = customPageViewModel = new CustomPageViewModel();
            customPageViewModel.SetpageTitle(page);
            this.simpleDelegate = simpleDelegate;
        }
        void AddGroup(object sender, System.EventArgs e)
        {
            simpleDelegate(group.Text);

        }
        async void Close(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
