// See https://aka.ms/new-console-template for more information

//great circle formula (https://www.geeksforgeeks.org/great-circle-distance-formula/)
//distance = r * arc-cosine[cos(a)cos(b)cos(x-y)+sin(a)sin(b)]
//r =earth's radius     a and b are latitudes       x and y are longitudes
//trig functions want radians but we have degrees
// radians=degress*(pi/180)
//earth's radius = 6378 km per https://imagine.gsfc.nasa.gov/features/cosmic/earth_info.html

//cleveland hopkins airport is 41.411230 N -81.838520 W
//Nashville airport is 36.135160 N -86.667860 W

using System.Runtime.InteropServices;

namespace straightLineDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 6378; //Earth's radius in kilometers

            double startlat, startlon, endlat, endlon;
            double temp_sina,temp_sinb,temp_cosa,temp_cosb,temp_cosab;
            double distance;

            //Cleveland Hopkins airport
            startlat = 41.411230; //a term
            startlon = -81.838520; //x term

            //Nashville International Airport
            endlat = 36.135160; //b term
            endlon = -86.667860; //y term

            //step 1 take the coordinates and turn them into radians
            startlat = startlat * (Math.PI / 180);
            startlon = startlon * (Math.PI / 180);
            endlat = endlat * (Math.PI / 180);
            endlon = endlon * (Math.PI / 180);

            //step2 find the sines and cosines
            temp_cosa = Math.Cos(startlat);
            temp_cosb = Math.Cos(endlat);
            temp_cosab = Math.Cos(startlon - endlon);

            temp_sina= Math.Sin(startlat);
            temp_sinb= Math.Sin(endlat);

            //distance = r * arc-cosine[cos(a)cos(b)cos(x-y)+sin(a)sin(b)] in kilometers
            distance = r * Math.Acos(temp_cosa * temp_cosb * temp_cosab + temp_sina * temp_sinb);
            Console.WriteLine(distance);

            //travelmath.com (https://www.travelmath.com/distance/from/BNA/to/CLE) gives the distance as 721 km
            //prgram gives 721.2472075091334 km

        }
    }
}
