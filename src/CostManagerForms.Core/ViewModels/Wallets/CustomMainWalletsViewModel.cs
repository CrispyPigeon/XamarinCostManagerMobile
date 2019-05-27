using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels._Base;
using CostManagerForms.Core.ViewModels.IncomeNotes;
using DAL.Services.CostManager;
using Model.RequestItems.Wallet;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Wallets
{
    public class CustomMainWalletsViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 0;

        private List<Wallet> _walletsList;
        public List<Wallet> WalletsList
        {
            get => _walletsList;
            set => SetProperty(ref _walletsList, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;

        public IMvxCommand CreateNewWalletCommand { get; }
        public IMvxCommand GoToIncomeNotesPageCommand { get; }

        public CustomMainWalletsViewModel(IMvxNavigationService navigation,
                                          ICostManagerService costManagerService)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;

            CreateNewWalletCommand = new MvxAsyncCommand<Wallet>((wallet) => GoToWalletDetailsPage(new Wallet()));
            GoToIncomeNotesPageCommand = new MvxAsyncCommand<Wallet>((wallet) => GoToIncomeNotesPage(wallet));
        }

        private async Task GoToIncomeNotesPage(Wallet wallet)
        {
            await _navigation.Navigate<IncomeNotesViewModel, Wallet>(wallet);
        }

        private async Task GoToWalletDetailsPage(Wallet wallet)
        {
            await _navigation.Navigate<WalletDetailsViewModel, Wallet>(wallet);
        }

        public override async Task LoadData()
        {
            await LoadingCommand(LoadingData);
        }

        private async Task LoadingData()
        {
            var walletsResponse = await _costManagerService.GetWallets(AppSettings.Instance.Token);
            if (walletsResponse.Data != null)
            {
                WalletsList = walletsResponse.Data;
            }
        }
    }
}
