using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinHorizontalList.Models;
using XamarinHorizontalList.Services;

namespace XamarinHorizontalList.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMonkeyService _monkeyService;

        private IEnumerable<Monkey> _monkeys;

        public IEnumerable<Monkey> Monkeys
        {
            get { return _monkeys; }
            set
            {
                _monkeys = value;
                RaisePropertyChanged();
            }
        }

        public MainPageViewModel(INavigationService navigationService, IMonkeyService monkeyService)
            : base(navigationService)
        {
            Title = "Monkeys Horizontal List";

            _monkeyService = monkeyService;
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Monkeys = await _monkeyService.GetMonkey();
        }
    }
}
