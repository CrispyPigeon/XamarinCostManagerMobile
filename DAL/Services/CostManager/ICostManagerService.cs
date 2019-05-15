using System.Threading.Tasks;
using Model.RequestItems.Base;

namespace DAL.Services.CostManager
{
    public interface ICostManagerService
    {
        Task<Message> SignInAsync(string userName, string password);
    }
}
