using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DAL.Services.CostManager;
using Model.RequestItems.Wallet;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Wallets
{
    public class WalletDetailsViewModel : BaseViewModel<Wallet>
    {
        private Wallet currentWallet;

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;
        private readonly IUserDialogs _dialogs;

        public IMvxCommand GoToIncomeNotesPageCommand { get; }

        public WalletDetailsViewModel(IMvxNavigationService navigation,
                                      ICostManagerService costManagerService,
                                      IUserDialogs dialogs)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;
            _dialogs = dialogs;

            GoToIncomeNotesPageCommand = new MvxAsyncCommand(SaveChanges);
        }

        private async Task SaveChanges()
        {

        }

        public override void Prepare(Wallet parameter)
        {
            
        }
    }
}
