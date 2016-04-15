using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace AppMvvm
{
	public class QrcodeScanner: ContentPage
	{
		ZXingScannerPage scanPage;
		Button buttonScanDefaultOverlay;
		Button buttonScanCustomOverlay;

		public QrcodeScanner()
		{
			buttonScanDefaultOverlay = new Button
			{
				Text = "Scan with Default Overlay",
			};

			buttonScanDefaultOverlay.Clicked += async delegate {
				
				scanPage = new ZXingScannerPage();

				scanPage.OnScanResult += (result) =>
				{
					scanPage.IsScanning = false;

					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.PopAsync();
						DisplayAlert("Scanned Barcode", result.Text, "OK");
					});
				};

				await Navigation.PushAsync(scanPage);
			};


			// button scan customOverlay
			buttonScanCustomOverlay = new Button
			{
				Text = "Scan with Custom Overlay"
			};
			buttonScanCustomOverlay.Clicked += async delegate {
				var customOverlay = new StackLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
				var torch = new Button
				{
					Text = "Toggle Torch"
				};
				torch.Clicked += delegate {
					scanPage.ToggleTorch();
				};
				customOverlay.Children.Add(torch);

				scanPage = new ZXingScannerPage(customOverlay: customOverlay);
				scanPage.OnScanResult += (result) =>
				{
					scanPage.IsScanning = false;
					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.PopAsync();
						DisplayAlert("Scanned Barcode", result.Text, "OK");
					});

				};

				await Navigation.PushAsync(scanPage);
			};

			var stack = new StackLayout();
			stack.Children.Add(buttonScanDefaultOverlay);
			stack.Children.Add(buttonScanCustomOverlay);

			Content = stack;
		}
	}
}

