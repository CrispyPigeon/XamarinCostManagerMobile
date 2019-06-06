using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels._Base;
using DAL.Services.CostManager;
using Model.Other;
using Model.RequestItems.CostCategory;
using Model.RequestItems.StorageType;
using Model.RequestItems.Wallet;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Costs
{
    public class CustomMainCostsViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 2;

        private List<JoinedCost> _allCostsList;

        private List<JoinedCost> _costsList;
        public List<JoinedCost> CostsList
        {
            get => _costsList;
            set => SetProperty(ref _costsList, value);
        }

        private Wallet _selectedWallet;
        public Wallet SelectedWallet
        {
            get => _selectedWallet;
            set
            {
                SetProperty(ref _selectedWallet, value);
                UpdateShowingData();
            }
        }

        private List<Wallet> _walletsList;
        public List<Wallet> WalletsList
        {
            get => _walletsList;
            set => SetProperty(ref _walletsList, value);
        }

        private CostCategory _selectedCostCategory;
        public CostCategory SelectedCostCategory
        {
            get => _selectedCostCategory;
            set
            {
                SetProperty(ref _selectedCostCategory, value);
                UpdateShowingData();
            }
        }

        private List<CostCategory> _costCategoriesList;
        public List<CostCategory> CostCategoriesList
        {
            get => _costCategoriesList;
            set => SetProperty(ref _costCategoriesList, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;

        public IMvxCommand CreateCostCommand { get; }
        public IMvxCommand GoToCostDetailsPageCommand { get; }

        public CustomMainCostsViewModel(IMvxNavigationService navigation,
                                        ICostManagerService costManagerService)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;
        }

        public override async Task LoadData()
        {
            await LoadingCommand(LoadingData);
        }

        private async Task LoadingData()
        {
            _allCostsList = new List<JoinedCost>();
            var costsResponse = await _costManagerService.GetCostsNotes(AppSettings.Instance.Token);
            var walletsResponse = await _costManagerService.GetWallets(AppSettings.Instance.Token);
            var costCategoryResponse = await _costManagerService.GetCostCategories(AppSettings.Instance.Token);
            var currencies = await _costManagerService.GetCurrencies(AppSettings.Instance.Token);
            if (walletsResponse.Data != null)
            {
                foreach (var item in costsResponse.Data)
                {
                    var wallet = walletsResponse.Data.FirstOrDefault(x => x.ID == item.WalletID);
                    var joinedWallet = new JoinedWallet(wallet,
                        new StorageType(),
                        currencies.Data.FirstOrDefault(x => x.ID == wallet.CurrencyID));
                    _allCostsList.Add(new JoinedCost(item,
                                                     joinedWallet,
                                                     costCategoryResponse.Data.FirstOrDefault(x => x.ID == item.CostCategoryID)));
                }
                if (_selectedWallet == null && _selectedCostCategory == null)
                {
                    WalletsList = walletsResponse.Data;
                    SelectedWallet = WalletsList.FirstOrDefault();
                    CostCategoriesList = costCategoryResponse.Data;
                    SelectedCostCategory = CostCategoriesList.FirstOrDefault();
                }
                else
                {
                    UpdateShowingData();
                }
            }
        }

        private void UpdateShowingData()
        {
            if (_selectedWallet == null && _selectedCostCategory == null)
            {
                CostsList = _allCostsList.Where(x => x.Wallet.Wallet.ID == _selectedWallet.ID &&
                                                x.CostCategory.ID == _selectedCostCategory.ID)
                                                .ToList();
            }
        }
    }
}
