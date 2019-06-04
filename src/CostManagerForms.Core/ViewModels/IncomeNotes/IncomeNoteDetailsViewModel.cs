using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CostManagerForms.Core.Localization;
using CostManagerForms.Core.Services.Settings;
using DAL.Services.CostManager;
using Model.RequestItems.IncomeNotes;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.IncomeNotes
{
    public class IncomeNoteDetailsViewModel : BaseViewModel<IncomeNote>
    {
        private IncomeNote _currentIncomeNote;
        public IncomeNote CurrentIncomeNote
        {
            get => _currentIncomeNote;
            set => SetProperty(ref _currentIncomeNote, value);
        }

        private bool _isSumEntryEnable;
        public bool IsSumEntryEnable
        {
            get => _isSumEntryEnable;
            set => SetProperty(ref _isSumEntryEnable, value);
        }

        private readonly IMvxNavigationService _navigation;
        private readonly ICostManagerService _costManagerService;
        private readonly IUserDialogs _dialogs;

        public IMvxCommand SaveChangesCommand { get; }

        public IncomeNoteDetailsViewModel(IMvxNavigationService navigation,
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
            if (!ValidateData())
            {
                _dialogs.Alert(AppResources.EmptyFieldsMessage, AppResources.ErrorTitle);
                return;
            }
            _currentIncomeNote.Date = DateTime.Now;
            var message = await _costManagerService.PostIncomeNoteAsync(AppSettings.Instance.Token, _currentIncomeNote);
            if (message.StatusCode != (int)HttpStatusCode.OK)
            {
                _dialogs.Alert(message.ReturnMessage, AppResources.ErrorTitle);
            }
            else
            {
                _dialogs.Alert(AppResources.DataSentMessage, AppResources.SuccessTitle);
                await _navigation.Close(this);
            }
        }

        private bool ValidateData()
        {
            if (Validate(_currentIncomeNote.Name) &&
                Validate(_currentIncomeNote.Sum))
                return true;
            else
                return false;
        }

        public override void Prepare(IncomeNote incomeNote)
        {
            _currentIncomeNote = incomeNote;
            if (incomeNote.ID == 0)
                IsSumEntryEnable = true;
        }
    }
}
