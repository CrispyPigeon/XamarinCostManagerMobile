using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Model.RequestItems.Wallet;
using DAL.Services.CostManager;
using System.Threading.Tasks;
using CostManagerForms.Core.Services.Settings;
using Model.RequestItems.IncomeNotes;
using System.Linq;
using CostManagerForms.Core.ViewModels.Wallets;

namespace CostManagerForms.Core.ViewModels.IncomeNotes
{
    public class IncomeNotesViewModel : BaseViewModel<Wallet>
    {
        private Wallet currentWallet;

        private List<IncomeNote> _incomeList;
        public List<IncomeNote> IncomeList
        {
            get => _incomeList;
            set => SetProperty(ref _incomeList, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;

        public IMvxCommand EditIncomeNote { get; }
        public IMvxCommand CreateIncomeNote { get; }
        public IMvxCommand EditWalletCommand { get; }

        public IncomeNotesViewModel(IMvxNavigationService navigation,
                                    ICostManagerService costManagerService)
        {
            _navigation = navigation;
            _costManagerService = costManagerService;

            CreateIncomeNote = new MvxAsyncCommand<IncomeNote>((incomeNote) => GoToIncomeDetailsPage(new IncomeNote
            {
                WalletID = currentWallet.ID
            }));
            EditIncomeNote = new MvxAsyncCommand<IncomeNote>((incomeNote) => GoToIncomeDetailsPage(incomeNote));
            EditWalletCommand = new MvxAsyncCommand<Wallet>((incomeNote) => GoToWalletDetailsPageAsync(currentWallet));
        }

        private async Task GoToWalletDetailsPageAsync(Wallet currentWallet)
        {
            await _navigation.Navigate<WalletDetailsViewModel, Wallet>(currentWallet);
        }

        private async Task GoToIncomeDetailsPage(IncomeNote incomeNote)
        {
            await _navigation.Navigate<IncomeNoteDetailsViewModel, IncomeNote>(incomeNote);
        }

        public override void Prepare(Wallet parameter)
        {
            currentWallet = parameter;
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await LoadIncomeNotes();
        }

        private async Task LoadIncomeNotes()
        {
            var incomeNotes = await _costManagerService.GetIncomeNotes(AppSettings.Instance.Token);
            IncomeList = incomeNotes.Data.Where(x => x.WalletID == currentWallet.ID).ToList();
        }
    }
}
