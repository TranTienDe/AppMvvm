﻿using System;
using AppMvvm;
using Xamarin.Forms;

namespace AppMvvm
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			//MainPage = new MainPage();
			//MainPage = new DemoView1();
			MainPage = new DemoView2();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

