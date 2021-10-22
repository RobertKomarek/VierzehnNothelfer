using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using VierzehnNothelfer.Models;
using Xamarin.Forms;
using VierzehnNothelfer.Views;

namespace VierzehnNothelfer.ViewModels
{
    public class NothelferViewModel : BaseViewModel
    {
        public ObservableCollection<NothelferBackup> NothelferCollection { get; set; }
        public ObservableCollection<NothelferBackup> ListeNothilfen { get; set; }

        private ObservableCollection<NothelferBackup> _nothilfe;
        public ObservableCollection<NothelferBackup> Nothilfe
        {
            get { return _nothilfe; }
            set { _nothilfe = value; OnPropertyChanged(); }
        }
       
        public Command<string> ZuMeinemHeiligenCommand { get; set; }

        public NothelferViewModel()
        {
            ZuMeinemHeiligenCommand = new Command<string>(ZumHeiligen);

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
        

        private async void ZumHeiligen(string heiliger)
        {
            //App.Current.MainPage.DisplayAlert("Info", $"{heiliger}", "OK"

            switch (heiliger)
            {
                case "Heiliger Achatius":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[0].Heiliger,
                            Bild = NothelferCollection[0].Bild,
                            Hintergrundfarbe = NothelferCollection[0].Hintergrundfarbe
                        }
                    };
                    
                    break;
                //case "Heiliger Aegidius":
                //    Nothilfe = NothelferCollection[1];
                //    break;
                //case "Heilige Barbara":
                //    Nothilfe = NothelferCollection[2];
                //    break;
                //case "Heiliger Blasius":
                //    Nothilfe = NothelferCollection[3];
                //    break;
                //case "Heiliger Christophorus":
                //    Nothilfe = NothelferCollection[4];
                //    break;
                //case "Heiliger Cyriakus":
                //    Nothilfe = NothelferCollection[5];
                //    break;
                //case "Heiliger Dionysius":
                //    Nothilfe = NothelferCollection[6];
                //    break;
                //case "Heiliger Erasmus":
                //    Nothilfe = NothelferCollection[7];
                //    break;
                //case "Heiliger Eustachius":
                //    Nothilfe = NothelferCollection[8];
                //    break;
                //case "Heiliger Georg":
                //    Nothilfe = NothelferCollection[9];
                //    break;
                //case "Heiliger Katharina":
                //    Nothilfe = NothelferCollection[10];
                //    break;
                //case "Heiliger Margareta":
                //    Nothilfe = NothelferCollection[11];
                //    break;
                //case "Heiliger Pantaleon":
                //    Nothilfe = NothelferCollection[12];
                //    break;
                //case "Heiliger Vitus":
                //    Nothilfe = NothelferCollection[13];
                //    break;
            }

            await App.Current.MainPage.Navigation.PushModalAsync(new NothilfeGebetPage(Nothilfe));
        }
    }
}
