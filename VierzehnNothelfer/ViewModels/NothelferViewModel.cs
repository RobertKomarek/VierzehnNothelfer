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

        private ObservableCollection<NothelferBackup> _nothilfe;
        public ObservableCollection<NothelferBackup> Nothilfe
        {
            get { return _nothilfe; }
            set { _nothilfe = value; }
        }

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
            //FÜR DIE CAROUSELVIEW GRUPPIEREN UND DEN ERSTEN EINTRAG AUSWÄHLEN
            DistinctHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).OrderBy(x => x.Heiliger).ToList();
            NothelferCollection = new ObservableCollection<NothelferBackup>(DistinctHeilige);
            //FÜR DIE STARTSEITE ALLE NOTHILFEN, GRUPPEN UND GRUPPENFARBEN AUSWÄHLEN
            InterimListeNothilfen = interimList.OrderBy(x => x.Gruppe).ToList();

            if (App.Current.Properties.ContainsKey("Spracheinstellungen"))
            {
                var sprachEinstellungen = Application.Current.Properties["Spracheinstellungen"].ToString();

                switch (sprachEinstellungen)
                {
                    case "Deutsch":
                        InterimListeNothilfen = InterimListeNothilfen.Where(x => x.Sprache == "Deutsch").ToList();
                        ListeNothilfen = new ObservableCollection<NothelferBackup>(InterimListeNothilfen);
                        //App.Current.MainPage.DisplayAlert("Einstellungen", "Sprache geändert auf Deutsch!", "OK");
                        break;

                    case "English":
                        InterimListeNothilfen = InterimListeNothilfen.Where(x => x.Sprache == "English").ToList();
                        ListeNothilfen = new ObservableCollection<NothelferBackup>(InterimListeNothilfen);
                        //App.Current.MainPage.DisplayAlert("Settings", "Language changed to English!", "OK");
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
                            Hintergrundfarbe = NothelferCollection[0].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[0].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[0].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Aegidius":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[1].Heiliger,
                            Bild = NothelferCollection[1].Bild,
                            Hintergrundfarbe = NothelferCollection[1].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[1].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[1].Nothelfergebet
                        }
                    };
                    break;
                case "Heilige Barbara":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[2].Heiliger,
                            Bild = NothelferCollection[2].Bild,
                            Hintergrundfarbe = NothelferCollection[2].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[2].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[2].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Blasius":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[3].Heiliger,
                            Bild = NothelferCollection[3].Bild,
                            Hintergrundfarbe = NothelferCollection[3].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[3].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[3].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Christophorus":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[4].Heiliger,
                            Bild = NothelferCollection[4].Bild,
                            Hintergrundfarbe = NothelferCollection[4].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[4].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[4].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Cyriakus":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[5].Heiliger,
                            Bild = NothelferCollection[5].Bild,
                            Hintergrundfarbe = NothelferCollection[5].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[5].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[5].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Dionysius":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[6].Heiliger,
                            Bild = NothelferCollection[6].Bild,
                            Hintergrundfarbe = NothelferCollection[6].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[6].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[6].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Erasmus":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[7].Heiliger,
                            Bild = NothelferCollection[7].Bild,
                            Hintergrundfarbe = NothelferCollection[7].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[7].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[7].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Eustachius":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[8].Heiliger,
                            Bild = NothelferCollection[8].Bild,
                            Hintergrundfarbe = NothelferCollection[8].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[8].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[8].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Georg":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[9].Heiliger,
                            Bild = NothelferCollection[9].Bild,
                            Hintergrundfarbe = NothelferCollection[9].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[9].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[9].Nothelfergebet
                        }
                    };
                    break;
                case "Heilige Katharina":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[10].Heiliger,
                            Bild = NothelferCollection[10].Bild,
                            Hintergrundfarbe = NothelferCollection[10].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[10].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[10].Nothelfergebet
                        }
                    };
                    break;
                case "Heilige Margareta":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[11].Heiliger,
                            Bild = NothelferCollection[11].Bild,
                            Hintergrundfarbe = NothelferCollection[11].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[11].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[11].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Pantaleon":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[12].Heiliger,
                            Bild = NothelferCollection[12].Bild,
                            Hintergrundfarbe = NothelferCollection[12].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[12].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[12].Nothelfergebet
                        }
                    };
                    break;
                case "Heiliger Vitus":
                    Nothilfe = new ObservableCollection<NothelferBackup>
                    {
                        new NothelferBackup
                        {
                            Heiliger = NothelferCollection[13].Heiliger,
                            Bild = NothelferCollection[13].Bild,
                            Hintergrundfarbe = NothelferCollection[13].Hintergrundfarbe,
                            Kurzbeschreibung = NothelferCollection[13].Kurzbeschreibung,
                            Nothelfergebet = NothelferCollection[13].Nothelfergebet
                        }
                    };
                    break;
            }

            await App.Current.MainPage.Navigation.PushModalAsync(new NothilfeGebetPage(Nothilfe));
        }
        #endregion
    }
}
