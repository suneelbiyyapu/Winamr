using System;
using System.Collections.Generic;
using System.Text;

namespace winamr.Contracts.Services.General
{
    public interface ISettingsService
    {
        void AddItem(string key, string value);
        string GetItem(string key);

        // User info
        string UserNameSetting { get; set; }
        string UserIdSetting { get; set; }
    }
}
