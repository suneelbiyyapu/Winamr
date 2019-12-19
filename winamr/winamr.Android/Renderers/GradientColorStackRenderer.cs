using Android.Content;
using Android.Graphics.Drawables;
using System;
using System.ComponentModel;
using winamr.Controls;
using winamr.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]

namespace winamr.Droid.Renderers
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public GradientColorStackRenderer(Context context):base(context)
        {

        }
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            UpdateGradientBackground();

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientColorStack;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GradientColorStack.StartColorProperty.PropertyName ||
                e.PropertyName == GradientColorStack.EndColorProperty.PropertyName)
            {
                UpdateGradientBackground();
            }

            base.OnElementPropertyChanged(sender, e);
        }

        //Called 
        protected override void UpdateBackgroundColor()
        {
            base.UpdateBackgroundColor();

            UpdateGradientBackground();
        }

        //Sets the background gradient color
        private void UpdateGradientBackground()
        {
            var button = this.Element as GradientColorStack;
            if (button != null)
            {
                int[] colors = new int[] { button.StartColor.ToAndroid(), button.EndColor.ToAndroid() };
                var gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.BlTr, colors);
                gradientDrawable.SetGradientType(GradientType.LinearGradient);
                gradientDrawable.SetShape(ShapeType.Rectangle);
                this.Background = gradientDrawable;
            }
        }
    }
}