using System;
using Xamarin.Forms;
using SQLite.Net.Interop;
using WerlonTrabalho1.Model;

[assembly: Dependency(typeof(WerlonTrabalho1.Droid.Config))]

namespace WerlonTrabalho1.Droid
{
    class Config : IConfig
    {
        private string _diretorioDB;
        private ISQLitePlatform _plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }
    }
}