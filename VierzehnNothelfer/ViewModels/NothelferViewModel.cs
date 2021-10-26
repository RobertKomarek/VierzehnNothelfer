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
        #region PROPERTIES & COMMANDS
        public ObservableCollection<NothelferBackup> NothelferCollection { get; set; }
        public List<NothelferBackup> DistinctHeilige { get; set; }
       
        public ObservableCollection<NothelferBackup> ListeNothilfen { get; set; }
        public List<NothelferBackup> InterimListeNothilfen { get; set; }
        public ObservableCollection<NothelferBackup> Nothilfe { get; set; }
       

        public Command<string> ZuMeinemHeiligenCommand { get; set; }
        public Command<string> ChangeLanguageCommand { get; set; }
        public Command StartPageAppearingCommand { get; set; }
        #endregion

        public NothelferViewModel()
        {
            #region CONSTRUCTOR PROPERTIES & COMMANDS
            ZuMeinemHeiligenCommand = new Command<string>(ZumHeiligen);
            ChangeLanguageCommand = new Command<string>(ChangeLanguage);
            StartPageAppearingCommand = new Command(StartPageAppearing);
            #endregion

            //ListeNothilfen = new ObservableCollection<NothelferBackup>();

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
            

            if (App.Current.Properties.ContainsKey("Spracheinstellungen"))
            {
                var sprachEinstellungen = Application.Current.Properties["Spracheinstellungen"].ToString();

                switch (sprachEinstellungen)
                {
                    case "Deutsch":
                        //FÜR DIE STARTSEITE ALLE NOTHILFEN, GRUPPEN UND GRUPPENFARBEN AUSWÄHLEN
                        InterimListeNothilfen = interimList.OrderBy(x => x.Gruppe).Where(x => x.Sprache == "Deutsch").ToList();
                        ListeNothilfen = new ObservableCollection<NothelferBackup>(InterimListeNothilfen);
                        //FÜR DIE CAROUSELVIEW GRUPPIEREN UND DEN ERSTEN EINTRAG AUSWÄHLEN
                        DistinctHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).Where(x => x.Sprache == "Deutsch").OrderBy(x => x.Heiliger).ToList();
                        NothelferCollection = new ObservableCollection<NothelferBackup>(DistinctHeilige);
                        break;

                    case "English":
                        InterimListeNothilfen = interimList.OrderBy(x => x.Gruppe).Where(x => x.Sprache == "English").ToList();
                        ListeNothilfen = new ObservableCollection<NothelferBackup>(InterimListeNothilfen);
                        DistinctHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).Where(x => x.Sprache == "English").OrderBy(x => x.Heiliger).ToList();
                        NothelferCollection = new ObservableCollection<NothelferBackup>(DistinctHeilige);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                InterimListeNothilfen = InterimListeNothilfen.Where(x => x.Sprache == "Deutsch").ToList();
                ListeNothilfen = new ObservableCollection<NothelferBackup>(InterimListeNothilfen);
            }
        }

        private void StartPageAppearing()
        {
            //await App.Current.MainPage.DisplayAlert("Page appeared", "went all right", "OK");
        }

        private void ChangeLanguage(string language)
        {
            SetProperties("Spracheinstellungen", language);
            App.Current.MainPage.DisplayAlert("Settings", $"Language changed to {language}!", "OK");
            App.Current.MainPage = new StartPage();
        }

        public async static void SetProperties(string property, object value)
        {
            var app = (App)Application.Current;
            app.Properties[property] = value;

            await app.SavePropertiesAsync();
        }

        #region METHOS ZUMHEILIGEN - NOTHILFEGEBETPAGE.XAML
        private async void ZumHeiligen(string bild)
        {
            //App.Current.MainPage.DisplayAlert("Info", $"{heiliger}", "OK"
            Nothilfe = new ObservableCollection<NothelferBackup>();

            for (int i = 0; i < NothelferCollection.Count; i++)
            {
                if (NothelferCollection[i].Bild == bild)
                {
                    Nothilfe.Add(new NothelferBackup
                    {
                        Heiliger = NothelferCollection[i].Heiliger,
                        Bild = NothelferCollection[i].Bild,
                        Hintergrundfarbe = NothelferCollection[i].Hintergrundfarbe,
                        Kurzbeschreibung = NothelferCollection[i].Kurzbeschreibung,
                        Nothelfergebet = NothelferCollection[i].Nothelfergebet
                    });
                }
            }

            await App.Current.MainPage.Navigation.PushModalAsync(new NothilfeGebetPage(Nothilfe));
        }
        #endregion
    }
}
