using System;
using System.Collections.Generic;
using System.Text;
using DAL.Services.CostManager;
using MvvmCross.Commands;

namespace CostManagerForms.Core.ViewModels.MainCommon
{
    public class MainCommonViewModel : BaseViewModel
    {
        private int _viewModelPosition;
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

        public MainCommonViewModel()
        {
            //Init ViewModels

            GoToWalletsPartCommand = new MvxCommand(() => ChangeView(1));
            GoToStatisticPartCommand = new MvxCommand(() => ChangeView(2));
            GoToCostsPartCommand = new MvxCommand(() => ChangeView(3));
        }

        private void ChangeView(int v)
        {
            ViewModelPosition = v;
        }
    }
}
