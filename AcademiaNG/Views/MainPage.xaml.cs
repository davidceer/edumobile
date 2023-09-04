using AcademiaNG.Helper;
using AcademiaNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        readonly RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            List<Organization> OrgRepositories = await _restService.GetAnythingAsync(Constants.AcademiaNGViewDataOrg);
            collectionView.ItemsSource = OrgRepositories;
        }
    }
}