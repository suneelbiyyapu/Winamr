using System;
using System.Collections.Generic;
using System.Text;
using winamr.Contracts.Services.General;
using Xamarin.Essentials;

namespace winamr.Services.General
{
    public class SettingsService : ISettingsService
    {
        private const string UserName = "UserName";
        private const string UserId = "UserId";

        public SettingsService()
        {
           // _settings = CrossSettings.Current;
        }

        public void AddItem(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public string GetItem(string key)
        {
            return Preferences.Get(key, string.Empty);
        }

        public string UserIdSetting
        {
            get => GetItem(UserId);
            set => AddItem(UserId, value);
        }

        public string UserNameSetting
        {
            get => GetItem(UserName);
            set => AddItem(UserName, value);
        }
    }
}
