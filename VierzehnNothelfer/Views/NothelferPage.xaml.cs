using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VierzehnNothelfer.Views
{
    public partial class NothelferPage : ContentPage
    {
        public NothelferPage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            //await myImage.TranslateTo(0, 200, 500);
            //await stCatarinaImage.TranslateTo(0, 200, 500);
            //label.TranslateTo(0, -200, 500);
            //await pancakeView.TranslateTo(0, -200, 500);
            //await lblHeilige.FadeTo(1, 1000);

            //await frame.TranslateTo(0, -200, 500);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        
    }
}
