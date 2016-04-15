using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppMvvm
{
	public partial class DemoView2 : ContentPage
	{
		public DemoView2 ()
		{
			InitializeComponent ();
		}

		private void OnValueChanged(object sender, ValueChangedEventArgs e)
		{
			lbValue.Text = ((Slider)sender).Value.ToString ("F3");
		}

		private async void OnButtonCliked(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			await DisplayAlert("Clicked me!",
				"The button labeled: " + button.Text + " has been clicked.",
				"OK");
		}
	}
}

