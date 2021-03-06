﻿using NewsForBuh.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace NewsForBuh.ViewModels
{
    public class SettingsViewModel:BaseViewModel
    {
        public bool ShowViewedNews
        { get => Preferences.Get(nameof(ShowViewedNews), false);
            set
            {
                Preferences.Set(nameof(ShowViewedNews), value);
                OnPropertyChanged(nameof(ShowViewedNews));
            }
        }
        
        
        
        public string NewsSection
        {
            get => Preferences.Get(nameof(NewsSection), ListSection[0]);
         
            set
            {
                Preferences.Set(nameof(NewsSection), value);
                OnPropertyChanged(nameof(NewsSection));
            }
        }
        
        public DateTime DateNewsFilter
        {
            get => Preferences.Get(nameof(DateNewsFilter), DateTime.Today);

            set
            {
                Preferences.Set(nameof(DateNewsFilter), value);
                OnPropertyChanged(nameof(DateNewsFilter));
            }
        }

        public List<string> ListSection { get; set; }

        public SettingsViewModel()
        {
            ListSection = new List<string>
                {
                   "Все разделы" ,
                   "Законодательство",
                   "Автоматизация"
                }; 
        }    
        
    }
}
