using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VierzehnNothelfer.Models;

using Xamarin.Forms;

namespace VierzehnNothelfer.Views
{
    public partial class NothilfeGebetPage : ContentPage
    {
        public ObservableCollection<NothelferBackup> Nothelfer { get; set; }

        public NothilfeGebetPage(ObservableCollection<NothelferBackup> nothelfer)
        {
            InitializeComponent();
            Nothelfer = new ObservableCollection<NothelferBackup>(nothelfer);

            //listView.ItemsSource = nothelfer;
            this.BindingContext = this;
        }

        public NothilfeGebetPage()
        {

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
