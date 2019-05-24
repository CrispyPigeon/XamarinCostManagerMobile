using System;
using System.Collections.Generic;
using System.Text;

namespace CostManagerForms.Core.Services.Settings
{
    public interface IAppSettings
    {
        string Token { get; }

        void SignIn(string token);
        void SignOut();
    }
}
