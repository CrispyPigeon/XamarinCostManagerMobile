using System;
using System.Collections.Generic;
using System.Text;

namespace CostManagerForms.Core.Services.SqLite
{
    public interface ISqLite
    {
        string GetDatabasePath(string filename);
    }
}
