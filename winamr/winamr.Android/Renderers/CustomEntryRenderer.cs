using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using winamr.Controls;
using winamr.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace winamr.Droid.Renderers
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = (CustomEntry)Element;
                var ourCustomColorHere = element.BorderColor.ToAndroid();
                Control.Background.SetColorFilter(ourCustomColorHere, PorterDuff.Mode.SrcAtop);

                //Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);

                /*
                GradientDrawable gd = new GradientDrawable();

                //Below line is useful to give border color
                gd.SetColor(global::Android.Graphics.Color.White);

                Control.SetBackground(gd);
                */
            }
        }
    }
}