using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoSQLite1.Interfaces;
using SQLite.Net.Interop;
using Windows.Storage;

namespace DemoSQLite1.UWP
{
    class Config: IConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    directorioDB = ApplicationData.Current.LocalFolder.Path;

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
                    plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }

                return plataforma;
            }

        }
    }
}
