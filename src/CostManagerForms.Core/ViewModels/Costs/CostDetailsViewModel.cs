using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CostManagerForms.Core.Localization;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels.CustomMain;
using DAL.Services.CostManager;
using Model.RequestItems.CostCategory;
using Model.RequestItems.Costs;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Costs
{
    public class CostDetailsViewModel : BaseViewModel<Cost>
    {
        private Cost _currentCost;
        public Cost CurrentCost
        {
            get => _currentCost;
            set => SetProperty(ref _currentCost, value);
        }

        private CostCategory _selectedCostCategory;
        public CostCategory SelectedCostCategory
        {
            get => _selectedCostCategory;
            set => SetProperty(ref _selectedCostCategory, value);
        }

        private List<CostCategory> _costCategoriesList;
        public List<CostCategory> CostCategoriesList
        {
            get => _costCategoriesList;
            set => SetProperty(ref _costCategoriesList, value);
        }

        private bool _isNew;
        public bool IsNew
        {
            get => _isNew;
            set => SetProperty(ref _isNew, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;
        private readonly IUserDialogs _dialogs;

        public IMvxCommand SaveChangesCommand { get; }
        public IMvxCommand DeleteCostCommand { get; }

        public CostDetailsViewModel(IMvxNavigationService navigation,
                                    ICostManagerService costManagerService,
                                    IUserDialogs dialogs)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;
            _dialogs = dialogs;

            SaveChangesCommand = new MvxAsyncCommand(SaveChanges);
            DeleteCostCommand = new MvxAsyncCommand(DeleteCost);
        }

        private async Task DeleteCost()
        {
            var confirmed = await _dialogs.ConfirmAsync(
                AppResources.QuestionRemoveCostMessage,
                AppResources.QuestionRemoveTitle,
                cancelText: AppResources.No);

            if (confirmed)
            {
                var result = await _costManagerService.DeleteCostAsync(AppSettings.Instance.Token, _currentCost.ID);
                if (result.IsSuccess)
                {
                    _dialogs.Alert(AppResources.RemoveSuccessfullyMessage, AppResources.CostTitle);
                    await _navigation.Close(this);
                }
            }
        }

        private async Task SaveChanges()
        {
            _currentCost.CostCategoryID = _selectedCostCategory.ID;
            _currentCost.Date = DateTime.Now;
            if (!ValidateData())
            {
                _dialogs.Alert(AppResources.EmptyFieldsMessage, AppResources.ErrorTitle);
                return;
            }
            var message = await _costManagerService.PostCostAsync(AppSettings.Instance.Token, _currentCost);
            if (message.StatusCode != (int)HttpStatusCode.OK)
            {
                _dialogs.Alert(message.ReturnMessage, AppResources.ErrorTitle);
            }
            else
            {
                _dialogs.Alert(AppResources.DataSentMessage, AppResources.SuccessTitle);
                await _navigation.Navigate<CustomMainViewModel>();
            }
        }

        private bool ValidateData()
        {
            if (Validate(_currentCost.Name) &&
                Validate(_currentCost.CostCategoryID) &&
                Validate(_currentCost.WalletID) &&
                Validate(_currentCost.Sum))
                return true;
            else
                return false;
        }

        public override void Prepare(Cost item)
        {
            _currentCost = item;
            if (_currentCost.ID == 0)
            {
                IsNew = true;
            }
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await LoadingCommand(LoadData);
        }

        private async Task LoadData()
        {
            var categoriesMessage = await _costManagerService.GetCostCategories(AppSettings.Instance.Token);
            CostCategoriesList = categoriesMessage.Data;
            SelectedCostCategory = CostCategoriesList.FirstOrDefault();
        }
    }
}
