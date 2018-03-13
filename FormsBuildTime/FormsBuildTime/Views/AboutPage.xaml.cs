using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsBuildTime.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
		}
	}
}