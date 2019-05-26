using System;
using System.Collections.Generic;
using System.Text;
using CostManagerForms.Core.ViewModels.Costs;
using CostManagerForms.Core.ViewModels.Menu;
using CostManagerForms.Core.ViewModels.Statistics;
using CostManagerForms.Core.ViewModels.Wallets;
using DAL.Services.CostManager;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.CustomMain
{
    public class CustomMainViewModel : BaseViewModel
    {
        public delegate void ViewLoaded();
        public event ViewLoaded ViewDidLoaded;

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

        public CustomMainViewModel(IMvxNavigationService navigation,
                                   ICostManagerService costManagerService)
        {
            _viewModels = new List<BaseViewModel>();
            var viewModel1 = new CustomMainWalletsViewModel();
            ViewDidLoaded += viewModel1.ViewLoaded;
            var viewModel2 = new CustomMainStatisticViewModel(costManagerService);
            ViewDidLoaded += viewModel2.ViewLoaded;
            var viewModel3 = new CustomMainCostsViewModel();
            ViewDidLoaded += viewModel3.ViewLoaded;
            _viewModels.Add(viewModel1);
            _viewModels.Add(viewModel2);
            _viewModels.Add(viewModel3);

            GoToWalletsPartCommand = new MvxCommand(() => ChangeView(0));
            GoToStatisticPartCommand = new MvxCommand(() => ChangeView(1));
            GoToCostsPartCommand = new MvxCommand(() => ChangeView(2));
           // OpenMenuCommand = new MvxAsyncCommand(async() => await navigation.Navigate<MenuViewModel>());
        }

        private void ChangeView(int v)
        {
            ViewModelPosition = v;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            ViewDidLoaded?.Invoke();
        }
    }
}
