﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using DemoSQLite1.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DemoSQLite1.Droid.Config))]

namespace DemoSQLite1.Droid
{
    class Config : IConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB{
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    directorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return directorioDB;

            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if(plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }

    }
}