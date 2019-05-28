using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.Localization;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels._Base;
using CostManagerForms.Core.ViewModels.IncomeNotes;
using DAL.Services.CostManager;
using Model.Other;
using Model.RequestItems.Currency;
using Model.RequestItems.StorageType;
using Model.RequestItems.Wallet;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Wallets
{
    public class CustomMainWalletsViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 0;

        private List<JoinedWallet> _allWalletsList;

        private List<JoinedWallet> _walletsList;
        public List<JoinedWallet> WalletsList
        {
            get => _walletsList;
            set => SetProperty(ref _walletsList, value);
        }

        private StorageType _selectedStorageType;
        public StorageType SelectedStorageType
        {
            get => _selectedStorageType;
            set
            {
                SetProperty(ref _selectedStorageType, value);
                UpdateShowingData();
            }
        }

        private void UpdateShowingData()
        {
            if (SelectedStorageType.ID == 0)
            {
                WalletsList = _allWalletsList;
            }
            else
            {
                WalletsList = _allWalletsList.Where(x => x.StorageType.ID == SelectedStorageType.ID)
                    .ToList();
            }
        }

        private List<StorageType> _storageTypeList;
        public List<StorageType> StorageTypeList
        {
            get => _storageTypeList;
            set => SetProperty(ref _storageTypeList, value);
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

            _allWalletsList = new List<JoinedWallet>();

            CreateNewWalletCommand = new MvxAsyncCommand<Wallet>((wallet) => GoToWalletDetailsPage(new Wallet()));
            GoToIncomeNotesPageCommand = new MvxAsyncCommand<JoinedWallet>((wallet) => GoToIncomeNotesPage(wallet));
        }

        private async Task GoToIncomeNotesPage(JoinedWallet wallet)
        {
            await _navigation.Navigate<IncomeNotesViewModel, Wallet>(wallet.Wallet);
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
            var storageTypes = await _costManagerService.GetStorageTypes(AppSettings.Instance.Token);
            var currencies = await _costManagerService.GetCurrencies(AppSettings.Instance.Token);
            if (walletsResponse.Data != null)
            {
                foreach (var item in walletsResponse.Data)
                {
                    _allWalletsList.Add(new JoinedWallet(item,
                                                     storageTypes.Data.FirstOrDefault(x => x.ID == item.StorageTypeID),
                                                     currencies.Data.FirstOrDefault(x => x.ID == item.CurrencyID)));
                }
                storageTypes.Data.Add(new StorageType { ID = 0, Name = AppResources.All });
                StorageTypeList = storageTypes.Data;
                SelectedStorageType = StorageTypeList.FirstOrDefault(x => x.ID == 0);
            }
        }
    }
}
