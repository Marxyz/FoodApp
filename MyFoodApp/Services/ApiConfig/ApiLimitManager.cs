using System;
using Windows.UI.Xaml;
using MyFoodApp.Models;

namespace MyFoodApp.Services.ApiConfig
{
    internal class ApiLimitManager : BaseViewModel
    {
        private readonly DispatcherTimer _timer;

        public ApiLimitManager()
        {
            QueryPerMinute = 0;
            _timer = new DispatcherTimer {Interval = TimeSpan.FromMinutes(1)};
            _timer.Tick += TimerOnTick;
            _timer.Start();
        }

        public int QueryPerMinute { get; set; }

        public bool IsQueryAvailable => QueryPerMinute < 5;

        private void TimerOnTick(object sender, object o)
        {
            QueryPerMinute = 0;
            OnPropertyChanged(nameof(QueryPerMinute));
        }

        public void IncrementQueryCount()
        {
            QueryPerMinute += 1;
            OnPropertyChanged(nameof(QueryPerMinute));
        }
    }
}