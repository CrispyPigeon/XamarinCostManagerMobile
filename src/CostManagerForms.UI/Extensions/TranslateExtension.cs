using System;
using CostManagerForms.Core.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace CostManagerForms.UI.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }


        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text is null)
            {
                return null;
            }

            var translation = ResourceController.GetString(Text);

#if DEBUG
            if (translation is null)
            {
                throw new ArgumentException($"Key {Text} was not found!");
            }
#endif
            return translation;
        }
    }
}
