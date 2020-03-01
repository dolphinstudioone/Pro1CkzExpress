using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using NewsForBuh.Models;
using NewsForBuh.ViewModels;
using NewsForBuh.Services;

namespace NewsForBuh.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            Date.Text = new SettingsViewModel().DateNewsFilter.ToString();
            Title = "Новости";
            
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            itemNews item = args.SelectedItem as itemNews;
            if (item == null)  return;

            Uri url = new Uri("http://pro1c.kz" + item.Link);
            Device.OpenUri(url);
            item.Read = true;
           
            App.Database.UpdateNewsAsync(item);
            ItemsListView.SelectedItem = null;
            
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
                viewModel.TextSearch = e.NewTextValue;
                viewModel.LoadItemsCommand.Execute(null);
             
        }

        async private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            itemNews item = ((Switch)sender).BindingContext as itemNews;
            await App.Database.UpdateNewsAsync(item);
            
        }
    }
}