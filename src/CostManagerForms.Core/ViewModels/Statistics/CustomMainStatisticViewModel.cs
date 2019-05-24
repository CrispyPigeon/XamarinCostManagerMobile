using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels._Base;
using DAL.Services.CostManager;
using Microcharts;
using Model.RequestItems;
using SkiaSharp;

namespace CostManagerForms.Core.ViewModels.Statistics
{
    public class CustomMainStatisticViewModel : BaseCarouselItemViewModel
    {
        private DonutChart _statisticChart;
        public DonutChart StatisticChart
        {
            get => _statisticChart;
            set => SetProperty(ref _statisticChart, value);
        }

        private string _test = "HI123";
        public string Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
        }

        private List<CostByWallet> _statisticList;
        public List<CostByWallet> StatisticList
        {
            get => _statisticList;
            set => SetProperty(ref _statisticList, value);
        }

        private readonly ICostManagerService _costManagerService;

        public CustomMainStatisticViewModel(ICostManagerService costManagerService)
        {
            _costManagerService = costManagerService;
            _statisticChart = new DonutChart();
        }

        public override async Task LoadData()
        {
            StatisticList = await _costManagerService.GetCommonStatistic();
            var statList = StatisticList.FirstOrDefault();

            StatisticChart.Entries = statList.Costs.Select(x => new Entry((float)x.Sum)
            {
                ValueLabel = x.Sum.ToString()
            }).ToArray(); 
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
