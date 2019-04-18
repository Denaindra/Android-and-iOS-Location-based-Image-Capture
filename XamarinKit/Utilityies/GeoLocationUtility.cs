using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
namespace XamarinKit.Utilityies
{
    public class GeoLocationUtility
    {
        public GeoLocationUtility()
        {
        }

        public async Task<Tuple<Position, bool>> GetLoation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 10;

            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                return new Tuple<Position, bool>(position, true);
            }
            return new Tuple<Position, bool>(null, false);

        }

        public async Task<bool> CheckPermissions(Permission permission)
        {
            var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(permission);
            if (newStatus.ContainsKey(permission) && newStatus[permission] != PermissionStatus.Granted)
            {
                return false;
            }
            return true;
        }
    }
}
