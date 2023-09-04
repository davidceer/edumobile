using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        readonly RestService _restService;
        public UserPage()
        {
            /*Task.Run(async () => {
                listUser.ItemsSource = await ReadData();
            });*/
            InitializeComponent();
            _restService = new RestService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<User> users = await _restService.GetUserAsync(Constants.AcademiaNGUserViewData);
            listUser.ItemsSource = users;
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "You want Quit", "OK");
            Application.Current.Quit();
        }

    }
}