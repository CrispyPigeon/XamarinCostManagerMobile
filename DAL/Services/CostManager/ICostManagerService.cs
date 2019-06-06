using System.Collections.Generic;
using System.Threading.Tasks;
using Model.RequestItems;
using Model.RequestItems.Base;
using Model.RequestItems.CostCategory;
using Model.RequestItems.Costs;
using Model.RequestItems.Currency;
using Model.RequestItems.IncomeNotes;
using Model.RequestItems.StorageType;
using Model.RequestItems.Wallet;

namespace DAL.Services.CostManager
{
    public interface ICostManagerService
    {
        Task<Login> SignInAsync(string userName, string password);
        Task<Message> RegisterAsync(string userName, string password);
        Task<Message<List<CostByWallet>>> GetCommonStatistic(string token);
        Task<Message<List<Wallet>>> GetWallets(string token);
        Task<Message<List<Currency>>> GetCurrencies(string token);
        Task<Message<List<StorageType>>> GetStorageTypes(string token);
        Task<Message<List<IncomeNote>>> GetIncomeNotes(string token);
        Task<Message<List<Cost>>> GetCostsNotes(string token);
        Task<Message<List<CostCategory>>> GetCostCategories(string token);
        Task<Message> PostWalletAsync(string token, Wallet wallet);
        Task<Message> PostIncomeNoteAsync(string token, IncomeNote incomeNote);
        Task<Message> PostCostAsync(string token, Cost cost);
        Task<Message> DeleteWalletAsync(string token, int walletId);
        Task<Message> DeleteIncomeNoteAsync(string token, int incomeId);
        Task<Message> DeleteCostAsync(string token, int costId); 
    }
}
