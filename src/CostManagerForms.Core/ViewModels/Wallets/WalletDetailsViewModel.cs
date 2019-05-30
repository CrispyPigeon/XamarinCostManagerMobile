using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CostManagerForms.Core.Localization;
using CostManagerForms.Core.Services.Settings;
using DAL.Services.CostManager;
using Model.RequestItems.Currency;
using Model.RequestItems.StorageType;
using Model.RequestItems.Wallet;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Wallets
{
    public class WalletDetailsViewModel : BaseViewModel<Wallet>
    {
        private Wallet _currentWallet;
        public Wallet CurrentWallet
        {
            get => _currentWallet;
            set => SetProperty(ref _currentWallet, value);
        }

        private List<Currency> _currencyList;
        public List<Currency> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }

        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set => SetProperty(ref _selectedCurrency, value);
        }

        private List<StorageType> _storageTypeList;
        public List<StorageType> StorageTypeList
        {
            get => _storageTypeList;
            set => SetProperty(ref _storageTypeList, value);
        }

        private StorageType _selectedStorageType;
        public StorageType SelectedStorageType
        {
            get => _selectedStorageType;
            set => SetProperty(ref _selectedStorageType, value);
        }

        private bool _isStoragePickerEnable;
        public bool IsStoragePickerEnable
        {
            get => _isStoragePickerEnable;
            set => SetProperty(ref _isStoragePickerEnable, value);
        }

        private bool _isCurrencyPickerEnable;
        public bool IsCurrencyPickerEnable
        {
            get => _isCurrencyPickerEnable;
            set => SetProperty(ref _isCurrencyPickerEnable, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;
        private readonly IUserDialogs _dialogs;

        public IMvxCommand SaveChangesCommand { get; }

        public WalletDetailsViewModel(IMvxNavigationService navigation,
                                      ICostManagerService costManagerService,
                                      IUserDialogs dialogs)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;
            _dialogs = dialogs;

            SaveChangesCommand = new MvxAsyncCommand(SaveChanges);
        }

        private async Task SaveChanges()
        {
            _currentWallet.CurrencyID = _selectedCurrency.ID;
            _currentWallet.StorageTypeID = _selectedStorageType.ID;
            var message = await _costManagerService.PostWalletAsync(AppSettings.Instance.Token, _currentWallet);
            if (message.StatusCode != (int)HttpStatusCode.OK)
            {
                _dialogs.Alert(message.ReturnMessage, AppResources.ErrorTitle);
                ClearFields();
            }
            else
            {
                _dialogs.Alert(AppResources.DataSentMessage, AppResources.SuccessTitle);
            }
        }

        public override void Prepare(Wallet parameter)
        {
            _currentWallet = parameter;
            if (parameter.ID == 0)
            {
                _isStoragePickerEnable = true;
                _isCurrencyPickerEnable = true;
            }
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await LoadingCommand(LoadData);
        }

        private async Task LoadData()
        {
            var currencyMessage = await _costManagerService.GetCurrencies(AppSettings.Instance.Token);
            CurrencyList = currencyMessage.Data;
            SelectedCurrency = CurrencyList.FirstOrDefault();
            var storageTypeMessage = await _costManagerService.GetStorageTypes(AppSettings.Instance.Token);
            StorageTypeList = storageTypeMessage.Data;
            SelectedStorageType = StorageTypeList.FirstOrDefault();
        }

        private void ClearFields()
        {
            CurrentWallet = new Wallet();
        }
    }
}
