using NewsForBuh.Models;
using NewsForBuh.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsForBuh.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookmarksPage : ContentPage
    {
        ItemsViewModel viewModel;
        public BookmarksPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();

            Title = "Избранное";
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            itemNews item = args.SelectedItem as itemNews;
            if (item == null) return;

            Uri url = new Uri("http://pro1c.kz" + item.Link);
            Device.OpenUri(url);
            item.Read = true;

            App.Database.UpdateNewsAsync(item);
            ItemsListView.SelectedItem = null;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadBookmarksCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.TextSearch = e.NewTextValue;
            viewModel.LoadBookmarksCommand.Execute(null);

        }
        async private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            itemNews item = ((CheckBox)sender).BindingContext as itemNews;
            await App.Database.UpdateNewsAsync(item);
            
        }

    }
}