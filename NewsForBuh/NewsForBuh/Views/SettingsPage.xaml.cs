using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewsForBuh.ViewModels;


namespace NewsForBuh.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel viewModel;
        public SettingsPage()
        {
            InitializeComponent();
             
            BindingContext = viewModel = new SettingsViewModel();
            SelectNewsSection.ItemsSource = viewModel.ListSection;
            SelectNewsSection.SelectedItem = viewModel.NewsSection;
            Title = "Настройки";
            

        }

        private void SelectNewsSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.NewsSection = SelectNewsSection.Items[SelectNewsSection.SelectedIndex];
            
        }
    }
}