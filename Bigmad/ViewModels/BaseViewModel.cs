using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinKit.Utilityies;

namespace XamarinKit.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public INavigation navigation;
        public RootViewModel rootViewModel;
        public const string loginUser = "loggedUser";
        public DatabaseUtility databaseUtility;
        public delegate void GetGroupName(String text);
        public MediaUtility mediaUtility;
        public LoadindIndicator indicator;
        public GetGroupName simpleDelegate;
        public GeoLocationUtility geoLocationUtility;

        public BaseViewModel()
        {
            mediaUtility = new MediaUtility();
            indicator = new LoadindIndicator();
            geoLocationUtility = new GeoLocationUtility();
            rootViewModel = new RootViewModel();
        }

        public bool CheckCameraMediea()
        {
           return mediaUtility.CheckCameraAvailability();
        }

        public bool CheckImageMedia()
        {
            return mediaUtility.CheckImagePickerAvailability();
        }

        public Task<MediaFile> CaptureImage()
        {
            return mediaUtility.CaptureImage();
        }

        public Task<MediaFile> BrowsImage()
        {
            return mediaUtility.BrowseGrallery();
        }

        public byte[] ConvertToByteArray(Stream imageStream)
        {
            byte[] img = new byte[imageStream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = imageStream.Read(img, 0, img.Length)) > 0)
                {
                    ms.Write(img, 0, read);
                }
                return ms.ToArray();
            }
        }

        public MemoryStream ConvertByteArrayToStream(byte[] img)
        {
            var imgeStream = new MemoryStream(img);
            return imgeStream;
        }

        public void SetCommonView()
        {
             simpleDelegate = (string newgroup) =>
            {
                AddNewGroup(newgroup);
                PopupNavigation.Instance.PopAsync();
            };
        }


        public virtual void AddNewGroup(string newItem) { }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
