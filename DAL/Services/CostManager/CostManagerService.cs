using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using DAL.Services.RequestProvider;
using Model.RequestItems;
using Model.RequestItems.Base;
using Model.RequestItems.Wallet;
using RestSharp;
using Xamarin.Forms;

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

        public async Task<Message> RegisterAsync(string userName, string password)
        {
            var request = Consts.RegistrationEndPoint;

            var bodyParameters = new List<(string, string)>
            {
                (Consts.ContentTypeUrlencoded, ParametersHelper.CreateBodyParameters(
                    new List<(string, string)>
                    {
                        (Consts.Login, userName),
                        (Consts.Password, password)
                    }))
            };

            return await _requestProvider.MakeApiCall<Message>(request,
                                                               Consts.ContentTypeUrlencoded,
                                                               Method.POST, bodyParametersList: bodyParameters)
                                                               ?? throw new Exception();
        }

        public async Task<Message<List<CostByWallet>>> GetCommonStatistic(string token)
        {
            var request = Consts.CommonStatisticsEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<CostByWallet>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message<List<Wallet>>> GetWallets(string token)
        {
            var request = Consts.WalletsEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<Wallet>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }
    }
}
