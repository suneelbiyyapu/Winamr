using UIKit;
using winamr.Controls;
using winamr.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace winamr.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Control.BorderStyle = UITextBorderStyle.None;

                // Below line is useful to give border color 
                Control.TintColor = UIColor.White;

                // Control.Layer.CornerRadius = 10;
                // Control.TextColor = UIColor.White;
            }
        }
    }
}