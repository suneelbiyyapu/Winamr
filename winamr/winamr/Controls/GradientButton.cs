using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace winamr.Controls
{
    public class GradientButton : Button
    {
        public enum GradientOrientation
        {
            Vertical,
            Horizontal
        }

        public GradientOrientation GradientColorOrientation
        {
            get; set;
        }

        /// <summary>
        /// Bindable property for button background gradient start color
        /// </summary>
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create("StartColor", typeof(Color), typeof(GradientButton), Color.Gray);

        /// <summary>
        /// Gets or sets the background gradient start color
        /// </summary>
        public Color StartColor
        {
            get { return (Color)this.GetValue(StartColorProperty); }
            set { this.SetValue(StartColorProperty, value); }
        }

        /// <summary>
        /// Bindable property for button background gradient end color
        /// </summary>
        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create("EndColor", typeof(Color), typeof(GradientButton), Color.Black);

        /// <summary>
        /// Gets or sets the background gradient end color
        /// </summary>
        public Color EndColor
        {
            get { return (Color)this.GetValue(EndColorProperty); }
            set { this.SetValue(EndColorProperty, value); }
        }
    }
}
