using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VierzehnNothelfer.Models;

using Xamarin.Forms;

namespace VierzehnNothelfer.Views
{
    public partial class NothilfeGebetPage : ContentPage
    {

        public NothilfeGebetPage(ObservableCollection<NothelferBackup> nothelfer)
        {
            InitializeComponent();
            listView.ItemsSource = nothelfer;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
