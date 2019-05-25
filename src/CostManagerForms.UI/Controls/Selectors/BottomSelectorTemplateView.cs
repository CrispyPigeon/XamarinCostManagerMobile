using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarouselView.FormsPlugin.Abstractions;
using CostManagerForms.UI.UiModels;
using Xamarin.Forms;

namespace CostManagerForms.UI.Controls.Selectors
{
    public class BottomSelectorTemplateView : ContentView
    {

        public BottomSelectorTemplateView()
        {
            stackLayouts = new List<StackLayout>();
        }

        private List<StackLayout> stackLayouts;

        private IEnumerable<TabbedItemControl> _tabbedItems;
        public IEnumerable<TabbedItemControl> TabbedItems
        {
            get => _tabbedItems;
            set
            {
                _tabbedItems = value;
                ChangeMenu();
            }
        }

        private void ChangeMenu()
        {
            var grid = new Grid
            {
                BackgroundColor = (Color)Application.Current.Resources["PrimaryColor"],
                ColumnSpacing = 0
            };

            foreach (var tabbedItem in _tabbedItems)
            {
                var stackLayout = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var label = new Label
                {
                    Text = tabbedItem.Name,
                    TextColor = (Color)Application.Current.Resources["SecondaryTextColor"],
                    HorizontalTextAlignment = TextAlignment.Center
                    
                };
                var image = new Image
                {
                    Source = tabbedItem.PicturePath,
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = LayoutOptions.Center
                };
                stackLayout.Children.Add(image);
                stackLayout.Children.Add(label);

                var tapGesture = new TapGestureRecognizer();
                tapGesture.SetBinding(TapGestureRecognizer.CommandProperty, tabbedItem.Command);
                
                stackLayout.GestureRecognizers.Add(tapGesture);

                stackLayouts.Add(stackLayout);

                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.Children.Add(stackLayout, grid.ColumnDefinitions.Count - 1, 0);

                if (tabbedItem != _tabbedItems.LastOrDefault())
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1) });
                    grid.Children.Add(new Label
                    {
                        BackgroundColor = (Color)Application.Current.Resources["PrimaryDarkColor"],
                    }, grid.ColumnDefinitions.Count - 1, 0);
                }
            }
            
            Content = grid;
        }

        private void ChooseItem(StackLayout stacklayout)
        {
            stacklayout.Style = (Style)Application.Current.Resources["SelectedMenuStackLayout"];
            foreach (var item in stackLayouts)
            {
                if (item != stacklayout)
                {
                    item.Style = (Style)Application.Current.Resources["MenuStackLayout"];
                }
            }
        }

        public void CarouselViewPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            ChooseItem(stackLayouts[e.NewValue]);
        }
    }
}
