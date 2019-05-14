using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace CostManagerForms.Core.Localization
{
    public static class ResourceController
    {
        public static string GetString(string text)
        {
            return GetManager().GetString(text);
        }

        public static ResourceManager GetManager()
        {
            return AppResources.ResourceManager;
        }
    }
}
