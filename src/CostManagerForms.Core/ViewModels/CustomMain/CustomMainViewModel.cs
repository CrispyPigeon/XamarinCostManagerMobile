using System;
using System.Collections.Generic;
using System.Text;
using CostManagerForms.Core.ViewModels.Costs;
using CostManagerForms.Core.ViewModels.Statistics;
using CostManagerForms.Core.ViewModels.Wallets;
using DAL.Services.CostManager;
using MvvmCross.Commands;

namespace CostManagerForms.Core.ViewModels.CustomMain
{
    public class CustomMainViewModel : BaseViewModel
    {
        private int _viewModelPosition = 1;
        public int ViewModelPosition
        {
            get => _viewModelPosition;
            set => SetProperty(ref _viewModelPosition, value);
        }

        private List<BaseViewModel> _viewModels;
        public List<BaseViewModel> ViewModels
        {
            get => _viewModels;
            set => SetProperty(ref _viewModels, value);
        }

        public IMvxCommand GoToStatisticPartCommand { get; }
        public IMvxCommand GoToWalletsPartCommand { get; }
        public IMvxCommand GoToCostsPartCommand { get; }
        public IMvxCommand OpenMenuCommand { get; }

        public CustomMainViewModel(ICostManagerService costManagerService)
        {
            _viewModels = new List<BaseViewModel>
            {
                new CustomMainWalletsViewModel(),
                new CustomMainStatisticViewModel(costManagerService),
                new CustomMainCostsViewModel()
            };

            GoToWalletsPartCommand = new MvxCommand(() => ChangeView(0));
            GoToStatisticPartCommand = new MvxCommand(() => ChangeView(1));
            GoToCostsPartCommand = new MvxCommand(() => ChangeView(2));
        }

        private void ChangeView(int v)
        {
            ViewModelPosition = v;
        }
    }
}
