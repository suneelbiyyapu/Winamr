using CoreAnimation;
using CoreGraphics;
using System.ComponentModel;
using winamr.Controls;
using winamr.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace winamr.iOS.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

        }
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            if (this.Element != null)
            {
                if (this.Element is GradientButton)
                {

                    var obj = (GradientButton)this.Element;
                    CGColor StartColor = obj.StartColor.ToCGColor();
                    CGColor EndColor = obj.EndColor.ToCGColor();
                    var gradientLayer = new CAGradientLayer();
                    gradientLayer.Frame = rect;
                    gradientLayer.Colors = new CGColor[] { StartColor, EndColor };

                    //for horizontal orientation
                    if (obj.GradientColorOrientation == GradientButton.GradientOrientation.Horizontal)
                    {
                        gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
                        gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
                    }
                    NativeView.Layer.InsertSublayer(gradientLayer, 0);
                }
            }
        }
    }
}