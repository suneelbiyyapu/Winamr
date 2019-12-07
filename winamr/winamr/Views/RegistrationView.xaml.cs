using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winamr.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace winamr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationView : GradientContentPage
    {
		public RegistrationView ()
		{
			InitializeComponent ();
		}
	}
}