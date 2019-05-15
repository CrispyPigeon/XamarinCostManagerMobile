using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace DAL.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private RestClient restClient;

        private string token;
        public string Token
        {
            get => token;
            set
            {
                token = value;
                restClient.RemoveDefaultParameter(Consts.Auth);
                restClient.AddDefaultHeader(Consts.Auth, string.Format(Consts.TypeOfToken, value));
            }
        }

        public RequestProvider()
        {
            restClient = new RestClient(Consts.BaseUrl);
        }

        public async Task<TResult> MakeApiCall<TResult>(string url,
                                                        string contentType,
                                                        Method method,
                                                        List<(string, string)> parametersList = null,
                                                        List<(string, string)> bodyParametersList = null,
                                                        object data = null)
                                                        where TResult : class
        {
            var request = new RestRequest(url, method)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = Consts.ContentTypeJson; }
            };

            request.AddHeader(Consts.ContentType, contentType);

            if (parametersList != null)
            {
                foreach ((string, string) parameter in parametersList)
                {
                    request.AddQueryParameter(parameter.Item1, parameter.Item2);
                }
            }

            if (bodyParametersList != null)
            {
                foreach ((string, string) parameter in bodyParametersList)
                {
                    request.AddParameter(parameter.Item1, parameter.Item2, ParameterType.RequestBody);
                }
            }

            if (data != null)
                request.AddParameter(Consts.ContentTypeJson, JsonConvert.SerializeObject(data), ParameterType.RequestBody);

            IRestResponse<TResult> response = await restClient.ExecuteTaskAsync<TResult>(request);

            return response.Data;
        }
    }
}
