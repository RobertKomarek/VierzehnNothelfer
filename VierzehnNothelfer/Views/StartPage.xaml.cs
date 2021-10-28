using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syncfusion.ListView;

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

        async void Flag_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new EinstellungenPage());
        }


        public double previousOffset { get; set; }

        async void CollectionView_Scrolled(System.Object sender, ScrolledEventArgs e)
        {
            if (previousOffset < e.ScrollY - 45) //scroll sensitivity
            {
                await bottomNavbarGrid.TranslateTo(0, 75, 300);
            }
            else if (previousOffset > e.ScrollY + 45)
            {
                await bottomNavbarGrid.TranslateTo(0, 0, 200);
            }
            else
            {
                return;
            }

            previousOffset = e.ScrollY;
        }

    }
}
