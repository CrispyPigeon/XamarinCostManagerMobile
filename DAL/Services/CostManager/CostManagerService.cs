using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using DAL.Services.RequestProvider;
using Model.RequestItems;
using Model.RequestItems.Base;
using Model.RequestItems.CostCategory;
using Model.RequestItems.Costs;
using Model.RequestItems.Currency;
using Model.RequestItems.IncomeNotes;
using Model.RequestItems.StorageType;
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

        public async Task<Message<List<Currency>>> GetCurrencies(string token)
        {
            var request = Consts.CurrencyEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<Currency>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message<List<StorageType>>> GetStorageTypes(string token)
        {
            var request = Consts.StorageTypesEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<StorageType>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message<List<IncomeNote>>> GetIncomeNotes(string token)
        {
            var request = Consts.IncomeNotesEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<IncomeNote>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message<List<Cost>>> GetCostsNotes(string token)
        {
            var request = Consts.CostsEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<Cost>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message<List<CostCategory>>> GetCostCategories(string token)
        {
            var request = Consts.CostCategoryEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message<List<CostCategory>>>(request,
                       Consts.ContentTypeUrlencoded,
                       Method.GET)
                   ?? throw new Exception();
        }

        public async Task<Message> PostWalletAsync(string token, Wallet wallet)
        {
            var request = Consts.WalletsEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               Consts.ContentTypeJson,                       
                                                               Method.POST,
                                                               data: wallet)
                   ?? throw new Exception();
        }

        public async Task<Message> PostIncomeNoteAsync(string token, IncomeNote incomeNote)
        {
            var request = Consts.IncomeNotesEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               Consts.ContentTypeJson,
                                                               Method.POST,
                                                               data: incomeNote)
                   ?? throw new Exception();
        }

        public async Task<Message> PostCostAsync(string token, Cost cost)
        {
            var request = Consts.CostsEndPoint;
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               Consts.ContentTypeJson,
                                                               Method.POST,
                                                               data: cost)
                   ?? throw new Exception();
        }

        public async Task<Message> DeleteWalletAsync(string token, int walletId)
        {
            var request = string.Concat(Consts.WalletsEndPoint, Consts.RequestSeparartor, walletId);
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               string.Empty,
                                                               Method.DELETE)
                   ?? throw new Exception();
        }

        public async Task<Message> DeleteIncomeNoteAsync(string token, int incomeId)
        {
            var request = string.Concat(Consts.IncomeNotesEndPoint, Consts.RequestSeparartor, incomeId);
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               string.Empty,
                                                               Method.DELETE)
                   ?? throw new Exception();
        }

        public async Task<Message> DeleteCostAsync(string token, int costId)
        {
            var request = string.Concat(Consts.CostsEndPoint, Consts.RequestSeparartor, costId);
            _requestProvider.Token = token;
            return await _requestProvider.MakeApiCall<Message>(request,
                                                               string.Empty,
                                                               Method.DELETE)
                   ?? throw new Exception();
        }        
    }
}
