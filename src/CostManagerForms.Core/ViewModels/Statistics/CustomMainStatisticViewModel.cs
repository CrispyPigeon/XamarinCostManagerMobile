using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.Controls.Entry;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels._Base;
using DAL.Services.CostManager;
using Microcharts;
using Model.RequestItems;
using SkiaSharp;

namespace CostManagerForms.Core.ViewModels.Statistics
{
    public class CustomMainStatisticViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 1;

        private bool _isChartVisible;
        public bool IsChartVisible
        {
            get => _isChartVisible;
            set => SetProperty(ref _isChartVisible, value);
        }

        private DonutChart _statisticChart;
        public DonutChart StatisticChart
        {
            get => _statisticChart;
            set => SetProperty(ref _statisticChart, value);
        }

        private List<CostByWallet> _statisticList;
        public List<CostByWallet> StatisticList
        {
            get => _statisticList;
            set => SetProperty(ref _statisticList, value);
        }

        private CostByWallet _selectedStatistic;
        public CostByWallet SelectedStatistic
        {
            get => _selectedStatistic;
            set
            {
                SetProperty(ref _selectedStatistic, value);
                UpdateChart();
            }
        }

        private readonly ICostManagerService _costManagerService;

        public CustomMainStatisticViewModel(ICostManagerService costManagerService)
        {
            _costManagerService = costManagerService;
        }

        public override async Task LoadData()
        {
            await LoadingCommand(LoadingData);
        }

        private async Task LoadingData()
        {
            var statisticListMessage = await _costManagerService.GetCommonStatistic(AppSettings.Instance.Token);

            if (statisticListMessage.Data != null)
            {
                if (StatisticList == null)
                    StatisticList = statisticListMessage.Data;
                else
                {
                    StatisticList.Clear();
                    StatisticList.AddRange(statisticListMessage.Data);
                }

                SelectedStatistic = StatisticList?.FirstOrDefault();
            }
        }

        private void UpdateChart()
        {
            if (SelectedStatistic == null || SelectedStatistic.Costs.Count == 0)
            {
                IsChartVisible = false;
                return;
            }
            else
            {
                IsChartVisible = true;
            }

            var entries = new List<ExtendedMicrochartsEntry>();
            foreach (var item in SelectedStatistic.Costs)
            {
                entries.Add(new ExtendedMicrochartsEntry((float)item.Sum)
                {
                    Label = item.CategoryName,
                    Color = SKColor.Parse(item.RgbColor),
                    RgbColor = item.RgbColor,
                    ValueLabel = item.Sum.ToString(),
                });
            }

            StatisticChart = new DonutChart()
            {
                Entries = entries,
                HoleRadius = 0.1f,
                LabelTextSize = 0f,
                BackgroundColor = SKColors.Transparent
            };
        }
    }
}
