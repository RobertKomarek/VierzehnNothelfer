﻿using System;
using VierzehnNothelfer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VierzehnNothelfer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new NothelferPage());
            //MainPage = new NothelferPage();
            //MainPage = new NavigationPage(new StartPage());
            MainPage = new StartPage();
            //MainPage = new NothilfeGebetPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
