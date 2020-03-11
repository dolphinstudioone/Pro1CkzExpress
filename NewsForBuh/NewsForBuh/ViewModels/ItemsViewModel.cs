using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using NewsForBuh.Models;
using System.Linq;


namespace NewsForBuh.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<itemNews> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadBookmarksCommand { get; set; }
        public string TextSearch { get; set; }

        private SettingsViewModel settingsView;
        public ItemsViewModel()
        {
            Items = new ObservableCollection<itemNews>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadBookmarksCommand = new Command(async () => await ExecuteLoadBookmarksCommand());
            settingsView = new SettingsViewModel();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            
            try
            {
                Items.Clear();
                var items = await App.Database.GetNewsWithArgsAsync(settingsView.NewsSection);

                items = items.Where(d => d.Date >= settingsView.DateNewsFilter).ToList();

                if (!string.IsNullOrEmpty(TextSearch))
                    items = items.FindAll(i => i.Title.ToLowerInvariant().Contains(TextSearch));

                if (settingsView.ShowViewedNews)
                    items = items.Where(r => r.Read == false).ToList();

                foreach (var item in items)
                {
                    Items.Add(item);   
                }              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    

        async Task ExecuteLoadBookmarksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await App.Database.GetBookmarksNewsAsync();

                if (!string.IsNullOrEmpty(TextSearch))
                    items = items.FindAll(i => i.Title.ToLowerInvariant().Contains(TextSearch));

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}