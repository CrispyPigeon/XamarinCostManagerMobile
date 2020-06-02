using System.Threading.Tasks;
using Acr.UserDialogs;
using CostManagerForms.Core.Localization;

namespace CostManagerForms.Core.Extensions
{
    public static class DialogExtensions
    {
        public static Task ShowConnectionError(this IUserDialogs userDialogs)
        {
            return userDialogs.AlertAsync(
                AppResources.NoConnectionMessage,
                AppResources.NoConnectionTitle);
        }

        public static Task<bool> ShowPermissionDeniedQuestion(this IUserDialogs userDialogs)
        {
            return userDialogs.ConfirmAsync(
                AppResources.PermissionDeniedMessage,
                AppResources.PermissionDeniedTitle,
                AppResources.OpenAppSettings);
        }
    }
}
