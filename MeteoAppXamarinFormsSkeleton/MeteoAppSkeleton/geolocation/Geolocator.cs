using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MeteoAppSkeleton.geolocation
{
    class Geolocator
    {
        
        public static async Task<Position> GetCurrentPosition()
        {
            return await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(5));
        }

    }
}
