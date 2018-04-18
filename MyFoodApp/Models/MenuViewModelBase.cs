using System.Collections.ObjectModel;

namespace MyFoodApp.Models
{
    internal class MenuViewModelBase : BaseViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppSecondMenu = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> Menu => AppMenu;
        public ObservableCollection<MenuItem> SecondMenu => AppSecondMenu;
    }
}