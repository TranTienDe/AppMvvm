using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AppMvvm
{
	public class MainViewModel: INotifyPropertyChanged
	{
		// khai bao bien gan noi bo
		private string _greeting;

		// khai bao thuoc tinh property
		public string Greeting { 
			get { return _greeting; }
			set { 
				_greeting = value;
				OnPropertyChanged ("Greeting");
			}
		}

		public string Name { get; set; }

		private bool _isBusy;
		public bool IsBusy {
			get { return _isBusy; }
			set {
				_isBusy = value;
				OnPropertyChanged ("IsBusy");
				OnPropertyChanged ("NotIsBusy");
			}		
		}

		public bool NotIsBusy {
			get { return !IsBusy; }
		}

		private int _widgetCount;
		public int WidgetCount{
			get { return _widgetCount; }
			set { 
				_widgetCount = value;
				OnPropertyChanged ("WidgetCount");
			}
		}

		// khai bao command cho cac button property
		public ICommand	SayHelloCommand{ get; set; }
		public ICommand CreateWidgetCommmand { get; set; }

		// khai bao doi tuong trong models
		public ObservableCollection<Employee> Employees { get; set; }


		// contrucstor
		public MainViewModel ()
		{
			Greeting = "Welcome Xamarin!";
			Name = "";

			// khoi tao gan data collections
			Employees = new ObservableCollection<Employee> 
			{
				new Employee { Name = "Tiến Đề", Age = 30, Address = "Đồng nai" },
				new Employee { Name = "Thanh Huyền", Age = 25, Address = "Đồng Nai" },
				new Employee { Name = "Tiến Đạt", Age = 1, Address = "Đồng Nai" }
			};

			//khoi tao Command
			SayHelloCommand = new Command (SayHello_Click);
			CreateWidgetCommmand = new Command (CreateWidget_Click);
		}

		// ham su kien click button
		public void SayHello_Click()
		{
			Greeting = "Hello " + Name;
		}

		public async void CreateWidget_Click()
		{
			IsBusy = true;
			await Task.Delay (2000);

			WidgetCount += 1;
			IsBusy = false;
		}

		#region INPC
		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}


