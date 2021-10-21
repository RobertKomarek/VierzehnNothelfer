using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using VierzehnNothelfer.Models;
using Xamarin.Forms;

namespace VierzehnNothelfer.ViewModels
{
    public class NothelferViewModel : ContentPage
    {
        public ObservableCollection<NothelferBackup> NothelferCollection { get; set; }
        public ObservableCollection<NothelferBackup> ListeNothilfen { get; set; }
        //public Command<string> ZumHeiligenCommand { get; set; }

        public NothelferViewModel()
        {
            //ZumHeiligenCommand = new Command<string>(ZumHeiligen);

            var interimList = new List<NothelferBackup>();
            var assembly = typeof(NothelferViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("VierzehnNothelfer.Resources.14Nothelfer.json");

            using (var reader = new StreamReader(stream))
            {
                if (reader != null)
                {
                    var jsonString = reader.ReadToEnd();
                    interimList = JsonConvert.DeserializeObject<List<NothelferBackup>>(jsonString);
                }
            }
            //FÜR DIE CAROUSELVIEW GRUPPIEREN UND DEN ERSTEN EINTRAG AUSWÄHLEN
            var distinctHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).OrderBy(x => x.LfdNummer).ToList();
            NothelferCollection = new ObservableCollection<NothelferBackup>(distinctHeilige);
            //FÜR DIE STARTSEITE ALLE NOTHILFEN, GRUPPEN UND GRUPPENFARBEN AUSWÄHLEN
            var interimListeNothilfen = interimList.OrderBy(x => x.Gruppe).ToList();
            ListeNothilfen = new ObservableCollection<NothelferBackup>(interimListeNothilfen);
        }

        //private void ZumHeiligen(string heiliger)
        //{
        //    App.Current.MainPage.DisplayAlert("Info", "TEST", "OK");

        //    switch (heiliger)
        //    {
        //        case "Heiliger Achatius":

        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
