using Plugin.Media.Abstractions;
using Xamarin.Forms;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class AddNewItemType : ContentPage
    {
        private AddNewItemViewModel addNewItemViewModel;
        private MediaFile mediaFile;
        public AddNewItemType(RootViewModel rootViewModel)
        {
            InitializeComponent();
            BindingContext = addNewItemViewModel = new AddNewItemViewModel();
            addNewItemViewModel.navigation = Navigation;
            addNewItemViewModel.rootViewModel = rootViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (addNewItemViewModel.rootViewModel.IsEdit)
            {
                addNewItemViewModel.GetItemTypeDetails();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            addNewItemViewModel.rootViewModel.IsEdit = false;
        }

        async void CameraClicked(object sender, System.EventArgs e)
        {

            if (!addNewItemViewModel.CheckCameraMediea())
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
            }
            else
            {
                mediaFile = await addNewItemViewModel.CaptureImage();
                img.Source = ImageSource.FromStream(() => mediaFile.GetStream());
            }

        }

        void SaveItem(object sender, System.EventArgs e)
        {
            if (addNewItemViewModel.rootViewModel.IsEdit)
            {
                addNewItemViewModel.UpdateItemType(mediaFile);
            }
            else
            {
                if (mediaFile != null)
                {
                    addNewItemViewModel.SaveItemTypeInfo(mediaFile);
                    mediaFile = null;
                }
                else
                {
                    DisplayAlert("No Image", "No Image available.", "OK");
                }
            }

            addNewItemViewModel.rootViewModel.IsEdit = false;
        }

        void RemoveItem(object sender, System.EventArgs e)
        {
            addNewItemViewModel.NavigationBack();
        }
    }
}
