using MyFoodApp.Services.Icons;
using MyFoodApp.Views;

namespace MyFoodApp.Models
{
    internal class MenuViewModel : MenuViewModelBase
    {
        public MenuViewModel()
        {
            Menu.Add(new MenuItem
            {
                Text = "Search",
                NavigationDestination = typeof(SearchPage),
                Glyph = Icons.GetIcon("SearchIcon")
            });
            Menu.Add(new MenuItem(){Text = "Me", Glyph = Icons.GetIcon("MeIcon"),NavigationDestination = typeof(MePage)});
            Menu.Add(new MenuItem(){Glyph = Icons.GetIcon("FridgeIcon"),Text = "Fridge", NavigationDestination = typeof(FridgePage)});
            SecondMenu.Add(new MenuItem
            {
                Text = "Settings",
                NavigationDestination = typeof(SettingsPage),
                Glyph = Icons.GetIcon("SettingsIcon")
            });
        }
    }
}