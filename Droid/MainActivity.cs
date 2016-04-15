using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AppMvvm.Droid
{
	[Activity(Theme = "@style/Theme.Splash",
		/*MainLauncher = true,*/
		NoHistory = true
		)] //Doesn't place it in back stack
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			System.Threading.Thread.Sleep(1000);
			this.StartActivity(typeof(MainActivity));
		}
	}

	[Activity (Label = "AppMvvm.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
		
			LoadApplication(new App ());
		}
	}
}

