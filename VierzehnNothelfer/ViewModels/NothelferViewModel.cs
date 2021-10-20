﻿using System;
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
        public ObservableCollection<string> ListeNothilfen { get; set; }
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
            //FÜR DIE CAROUSELVIEW GRUPPIEREN UND DEN ERSTEN EINTRAG AUSWÄHLEN
            var distinctHeilige = interimList.GroupBy(x => x.Heiliger).Select(x => x.First()).ToList();
            NothelferCollection = new ObservableCollection<NothelferBackup>(distinctHeilige);
            //FÜR DIE STARTSEITE ALLE NOTHILFEN AUSWÄHLEN UND ALPHA
            var nurNothilfen = interimList.OrderBy(x => x.Nothilfe).Select(x => x.Nothilfe).ToList();
            ListeNothilfen = new ObservableCollection<string>(nurNothilfen);
        }
           
            //MeineNothelfer = new NothelferBackup();
            //VierzehnNothelfer = new ObservableCollection<NothelferBackup>(MeineNothelfer.NothelferBackupListe());
    }
}
