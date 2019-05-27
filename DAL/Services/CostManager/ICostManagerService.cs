using System.Collections.Generic;
using System.Threading.Tasks;
using Model.RequestItems;
using Model.RequestItems.Base;
using Model.RequestItems.Wallet;

namespace DAL.Services.CostManager
{
    public interface ICostManagerService
    {
        Task<Login> SignInAsync(string userName, string password);
        Task<Message> RegisterAsync(string userName, string password);
        Task<Message<List<CostByWallet>>> GetCommonStatistic(string token);
        Task<Message<List<Wallet>>> GetWallets(string token);
    }
}
