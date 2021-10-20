using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VierzehnNothelfer.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new NothelferPage());
            //Ohne Zurück-Button:
            await Navigation.PushModalAsync(new NothelferPage());
        }
        
    }
}
