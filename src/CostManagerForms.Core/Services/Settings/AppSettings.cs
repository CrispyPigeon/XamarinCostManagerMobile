using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings.Abstractions;

namespace CostManagerForms.Core.Services.Settings
{
    public class AppSettings : IAppSettings
    {

        public static AppSettings Instance { get; private set; }

        private const string TokenKey = "Token";

        private readonly ISettings _settings;

        public AppSettings(ISettings settings)
        {
            _settings = settings;

            Instance = this;
        }

        public string Token
        {
            get => _settings.GetValueOrDefault(TokenKey, string.Empty);
            private set => _settings.AddOrUpdateValue(TokenKey, value);
        }

        public void SignIn(string token)
        {
            Token = token;
        }

        public void SignOut()
        {
            Token = string.Empty;
        }
    }
}
