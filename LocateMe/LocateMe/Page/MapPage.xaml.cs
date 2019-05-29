using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace LocateMe.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		private bool nameStackLayout;
		private double lati;
		private double longi;

		public MapPage ()
		{
			InitializeComponent ();
			popup.IsVisible = true;
			StackNameLayout.IsVisible = false;
			getLocation();
			MyMap.MyLocationEnabled = true;
			
		}

		private void CancelTapped(object sender, EventArgs e)
		{
			popup.IsVisible = false;
		}

		public double LatitudeLabel { get; set; }
		public double LongitudeLabel { get; set; }
		
		private async void getLocation()
		{
			var request = new GeolocationRequest(GeolocationAccuracy.High);
			var location = await Geolocation.GetLocationAsync(request);
			
			latitude.Text = location.Latitude.ToString();
			longitute.Text = location.Longitude.ToString();
		}

		public void MyMap_MapLongClicked(object sender, Xamarin.Forms.GoogleMaps.MapLongClickedEventArgs e)
		{
			popup.IsVisible = false;
			lati = e.Point.Latitude;
			longi = e.Point.Longitude;
			StackNameLayout.IsVisible = true;
		}

		public void SaveButtonClicked(object sender, EventArgs e)
		{
			var locationName = nameEntry.Text;
			var pin = new Pin()
			{
				Position = new Xamarin.Forms.GoogleMaps.Position(lati,longi),
				Label = locationName
			};
			MyMap.Pins.Add(pin);
			StackNameLayout.IsVisible = false;
		}
	}
}