using System;
using System.IO;
using CostManagerForms.Core.Services.SqLite;

namespace CostManagerForms.Droid.Service.SqLite
{
    public class SqLiteService : ISqLite
    {
        public string GetDatabasePath(string fileName)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            return path;
        }
    }
}
