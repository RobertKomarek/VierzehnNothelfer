using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VierzehnNothelfer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            lblHeilige.Opacity = 0;

            await stCatarinaImage.TranslateTo(0, 200, 500);
            label.TranslateTo(0, -200, 500);
            await pancakeView.TranslateTo(0, -200, 500);
            //await frame.TranslateTo(0, -200, 500);
            await lblHeilige.FadeTo(1, 1000);
        }
    }
}
