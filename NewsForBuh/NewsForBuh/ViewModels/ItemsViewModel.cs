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
        public string TextSearch { get; set; }
        public ItemsViewModel()
        {

            Items = new ObservableCollection<itemNews>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            /*MessagingCenter.Subscribe<NewItemPage, itemNews>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as itemNews;
                Items.Add(newItem);

                await App.Database.SaveNewsAsync(newItem);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            
            try
            {
                Items.Clear();
                var items = await App.Database.GetAllNewsAsync();
                
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