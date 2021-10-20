using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using VierzehnNothelferBackup.Models;
using Xamarin.Forms;

namespace VierzehnNothelfer.ViewModels
{
    public class NothelferViewModel : ContentPage
    {
        public ObservableCollection<NothelferBackup> NothelferCollection { get; set; }
        //public ObservableCollection<NothelferBackup> VierzehnNothelfer { get; set; }
        //public NothelferBackup MeineNothelfer { get; set; }

        public NothelferViewModel()
        {
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

            var distintHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).ToList();
            NothelferCollection = new ObservableCollection<NothelferBackup>(distintHeilige);

            
        }
           
            //MeineNothelfer = new NothelferBackup();
            //VierzehnNothelfer = new ObservableCollection<NothelferBackup>(MeineNothelfer.NothelferBackupListe());
    }
}
