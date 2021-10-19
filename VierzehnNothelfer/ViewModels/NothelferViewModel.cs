using System;
using System.Collections.ObjectModel;
using VierzehnNothelferBackup.Models;
using Xamarin.Forms;

namespace VierzehnNothelfer.ViewModels
{
    public class NothelferViewModel : ContentPage
    {
        public ObservableCollection<NothelferBackup> VierzehnNothelfer { get; set; }
        public NothelferBackup MeineNothelfer { get; set; }

        #region COMMANDS
        #endregion


        public NothelferViewModel()
        {
            MeineNothelfer = new NothelferBackup();
            VierzehnNothelfer = new ObservableCollection<NothelferBackup>(MeineNothelfer.NothelferBackupListe());
        }

      
    }
}
