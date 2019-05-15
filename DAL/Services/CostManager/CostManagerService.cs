using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using DAL.Services.RequestProvider;
using Model.RequestItems;
using Model.RequestItems.Base;
using RestSharp;

namespace DAL.Services.CostManager
{
    public class CostManagerService : ICostManagerService
    {
        private readonly IRequestProvider _requestProvider;

        public CostManagerService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Login> SignInAsync(string userName, string password)
        {
            var request = Consts.LoginEndPoint;

            var bodyParameters = new List<(string, string)>
            {
                (Consts.ContentTypeUrlencoded, ParametersHelper.CreateBodyParameters(
                    new List<(string, string)>
                    {
                        (Consts.GrantType, Consts.Password),
                        (Consts.Username, userName),
                        (Consts.Password, password)
                    }))
            };

            var login = await _requestProvider.MakeApiCall<Login>(request,
                                                                  Consts.ContentTypeUrlencoded,
                                                                  Method.POST, bodyParametersList: bodyParameters)
                                                                  ?? throw new Exception();

            _requestProvider.Token = login.Token;

            return login;
        }
    }
}
