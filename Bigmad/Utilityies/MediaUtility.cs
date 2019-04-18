using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace XamarinKit.Utilityies
{
    public class MediaUtility
    {
        private MediaFile mediaFiles;

        public MediaUtility()
        {

        }

        public bool CheckCameraAvailability()
        {
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                return true;
            }
            return false;
        }

        public bool CheckImagePickerAvailability()
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                return true;
            }
            return false;
        }

        public async Task<MediaFile> CaptureImage()
        {
            mediaFiles = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "GroupItemPhotos",
                SaveToAlbum = true,
                CompressionQuality = 10,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium,
                MaxWidthHeight = 150,
                DefaultCamera = CameraDevice.Rear,
                Name = DateTime.Now.ToString() + ".jpg"
            });
            return mediaFiles;
        }

        public async Task<MediaFile> BrowseGrallery()
        {
            var ImageMedia = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 10,
                MaxWidthHeight = 150

            });

            return ImageMedia;
        }
    }
}
