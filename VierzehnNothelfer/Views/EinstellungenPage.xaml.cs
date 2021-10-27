using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace VierzehnNothelfer.Views
{
    public partial class EinstellungenPage : ContentPage
    {
        public EinstellungenPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
