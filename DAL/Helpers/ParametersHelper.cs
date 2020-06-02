using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helpers
{
    public static class ParametersHelper
    {
        public static string CreateBodyParameters(List<(string, string)> parameters)
        {
            var result = string.Empty;
            for(var i = 0; i < parameters.Count; i++)
            {
                if (i == 0)
                {
                    result = string.Format("{0}={1}", parameters[i].Item1, parameters[i].Item2);
                }
                else
                {
                    result += string.Format("&{0}={1}", parameters[i].Item1, parameters[i].Item2);
                }
            }
            return result;
        }
    }
}
