using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace DAL.Services.RequestProvider
{
    public interface IRequestProvider
    {
        string Token { get; set; }
        
        Task<TResult> MakeApiCall<TResult>(string url,
                                           string contentType,
                                           Method method,
                                           List<(string, string)> parametersList = null,
                                           List<(string, string)> bodyParametersList = null,
                                           object data = null)
                                           where TResult : class;
    }
}
