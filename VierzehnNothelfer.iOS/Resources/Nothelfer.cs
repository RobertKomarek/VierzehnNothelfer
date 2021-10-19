using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace VierzehnNothelfer
{
    public class Nothelfer
    {
        public string Heiliger { get; set; }
        public string Kurzbeschreibung { get; set; }
        public string Zustaendigkeit { get; set; }
        public string Anmerkung { get; set; }
        public string Bild { get; set; }
        public int LfdNummer { get; set; }
        public string Sprache { get; set; }
        public DateTime Gedenktag { get; set; }
        public string Nothilfe { get; set; }
        public string Patronat { get; set; }
        public Color Hintergrundfarbe { get; set; }

        public Nothelfer()
        {

        }

        public ObservableCollection<Nothelfer> NothelferListe()
        {
            var notherhelferListe = new ObservableCollection<Nothelfer>();

            notherhelferListe.Add(new Nothelfer
            {
                LfdNummer = 11,
                Bild = "StCatarina",
                Heiliger = "Heilige Katharina",
                Kurzbeschreibung = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen",
                Zustaendigkeit = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen, auch Helferin bei Leiden der Zunge und Sprachschwierigkeiten, und Patronin" +
                " der Gelehrten sowie auch zahlreicher Handwerksberufe",
                Anmerkung = "Katharina erlitt das Martyrium unter Kaiser Maxentius im Anschluss an einen " +
                "theologischen Disput. Da das Rad zerbrach, auf dem sie gerädert werden sollte, wurde sie mit dem Schwert enthauptet.",
                Hintergrundfarbe = Color.FromHex("#2B6293")
            });

            notherhelferListe.Add(new Nothelfer
            {
                LfdNummer = 11,
                Bild = "StAchatius",
                Heiliger = "Heiliger Achatius",
                Kurzbeschreibung = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen",
                Zustaendigkeit = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen, auch Helferin bei Leiden der Zunge und Sprachschwierigkeiten, und Patronin" +
                " der Gelehrten sowie auch zahlreicher Handwerksberufe",
                Anmerkung = "Katharina erlitt das Martyrium unter Kaiser Maxentius im Anschluss an einen " +
                "theologischen Disput. Da das Rad zerbrach, auf dem sie gerädert werden sollte, wurde sie mit dem Schwert enthauptet.",
                Hintergrundfarbe = Color.FromHex("#3B6253")
            });

            notherhelferListe.Add(new Nothelfer
            {
                LfdNummer = 11,
                Bild = "StVitus",
                Heiliger = "Heiliger Vitus",
                Kurzbeschreibung = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen",
                Zustaendigkeit = "Beschützerin der Mädchen, Jungfrauen und Ehefrauen, auch Helferin bei Leiden der Zunge und Sprachschwierigkeiten, und Patronin" +
               " der Gelehrten sowie auch zahlreicher Handwerksberufe",
                Anmerkung = "Katharina erlitt das Martyrium unter Kaiser Maxentius im Anschluss an einen " +
               "theologischen Disput. Da das Rad zerbrach, auf dem sie gerädert werden sollte, wurde sie mit dem Schwert enthauptet.",
                Hintergrundfarbe = Color.FromHex("#D4AD6E")
            }); ;

            return notherhelferListe;
        }

    }
}
