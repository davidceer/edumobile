using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : TabbedPage
    {
        //public ICommand NavigateCommand { private set; get; }
        readonly DashboardViewModel mViewModel;
        public IEnumerable<LoginDetails> NewSource { get; set; }

        public Dashboard(IEnumerable<LoginDetails> source, IEnumerable<LoginDetails> students)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //collectionView.ItemsSource = source;
            //listView.ItemsSource = students;
            //Populate class students to the ViewModel
            mViewModel = new DashboardViewModel(source, students);
            BindingContext = mViewModel;
            NewSource = source;
            //https://stackoverflow.com/questions/61475605/xamarin-forms-display-data-grid
        }

        private async void ProfileUpdate_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserEditPage(NewSource));
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as Xamarin.Forms.ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                DashboardViewModel pageData = args.SelectedItem as DashboardViewModel;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushModalAsync(page);
            }
        }
    }
}