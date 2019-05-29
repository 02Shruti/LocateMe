using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;

namespace LocateMe.Droid
{
    [Activity(Label = "LocateMe", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
			ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessLocationExtraCommands, Manifest.Permission.AccessNetworkState, Manifest.Permission.AccessWifiState }, 101);


            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			//Xamarin.FormsMaps.Init(this, savedInstanceState);
			Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
			LoadApplication(new App());
			
		}
    }
}