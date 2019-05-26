using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                UpdateChart();
                SetProperty(ref _selectedStatistic, value);
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
                StatisticList = statisticListMessage.Data;

                var statList = StatisticList.FirstOrDefault();

                SelectedStatistic = StatisticList?.FirstOrDefault();

                UpdateChart();
            }
        }

        private void UpdateChart()
        {
            if (SelectedStatistic == null)
                return;

            if (SelectedStatistic.Costs.Count == 0)
            {
                IsChartVisible = false;
                return;
            }
            else
            {
                IsChartVisible = true;
            }

            var entries = new List<Entry>();
            foreach (var item in SelectedStatistic.Costs)
            {
                entries.Add(new Entry((float)item.Sum)
                {
                    Label = item.CategoryName,
                    Color = SKColor.Parse(item.RgbColor),
                    ValueLabel = item.Sum.ToString(),
                });
            }

            StatisticChart = new DonutChart()
            {
                Entries = entries,
                HoleRadius = 0.1f,
                LabelTextSize = 40f,
                BackgroundColor = SKColors.Transparent
            };
        }
    }
}
