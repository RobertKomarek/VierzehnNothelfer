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


        public double previousScrollPostion = 0;
        async void CollectionView_Scrolled(System.Object sender, ScrolledEventArgs e)
        {
            if (previousScrollPostion < e.ScrollY ) //scroll sensitivity
            {
                await bottomNavbarGrid.TranslateTo(0, 75, 225);
            }
            else 
            {
                await bottomNavbarGrid.TranslateTo(0, 0, 200);
                previousScrollPostion = 0;
            }
            
        }

    }
}
