using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using System;
using System.ComponentModel;
using winamr.Controls;
using winamr.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace winamr.Droid.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {

        public GradientButtonRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            UpdateGradientBackground();
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GradientButton.StartColorProperty.PropertyName ||
                e.PropertyName == GradientButton.EndColorProperty.PropertyName ||
                e.PropertyName == GradientButton.BorderColorProperty.PropertyName ||
                e.PropertyName == GradientButton.CornerRadiusProperty.PropertyName ||
                e.PropertyName == GradientButton.BorderWidthProperty.PropertyName)
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
            var button = this.Element as GradientButton;
            if (button != null)
            {
                int[] colors = new int[] { button.StartColor.ToAndroid(), button.EndColor.ToAndroid() };
                var gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.BlTr, colors);
                gradientDrawable.SetGradientType(GradientType.LinearGradient);
                gradientDrawable.SetShape(ShapeType.Rectangle);
                gradientDrawable.SetCornerRadius(button.CornerRadius);
                gradientDrawable.SetStroke((int)button.BorderWidth, button.BorderColor.ToAndroid());
                this.Control.Background = gradientDrawable;
            }
        }
    }
}