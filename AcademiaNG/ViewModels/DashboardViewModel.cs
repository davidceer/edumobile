using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class DashboardViewModel : BaseViewModel //SettingsData
    {
        public IEnumerable<LoginDetails> Categories { get; set; }
        public Type Type { private set; get; }
        public new string Title { private set; get; }
        public string Description { private set; get; }
        public static IList<DashboardViewModel> All { private set; get; }

        private LoginDetails _tappedItem;
        public Command<object> TapCommand { get; set; }
        public Command<object> DoneCommand { get; set; }

        public LoginDetails TappedItem
        {
            get => _tappedItem;
            set
            {
                _tappedItem = value;
                OnPropertyChanged("TappedItem");
            }
        }

        private IEnumerable<LoginDetails> _items;
        public IEnumerable<LoginDetails> StudentsItems
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("StudentsItems");
            }
        }

        private IEnumerable<LoginDetails> _settingsData;
        public IEnumerable<LoginDetails> SettingsData
        {
            get { return _settingsData; }
            set
            {
                _settingsData = value;
                OnPropertyChanged("SettingsData");
            }
        }
        
        public DashboardViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public DashboardViewModel()
        {
        }

        static DashboardViewModel()
        {
            All = new List<DashboardViewModel>
            {
                // Part 1. Getting Started with XAML
                new DashboardViewModel(typeof(UserPage), "Hello, XAML", "Display a Label with many properties set"),
                new DashboardViewModel(typeof(RegisterPage), "XAML + Code", "Interact with a Slider and Button"),            
            };
        }

        public DashboardViewModel(IEnumerable<LoginDetails> source, IEnumerable<LoginDetails> students = null)
        {
            Title = "DashBoard";
            if(source != null)
            {
                SettingsData = source;
                StudentsItems = students;
            }

            TapCommand = new Command<object>(ButtonTapped);
            DoneCommand = new Command<object>(DoneTapped);

            //This seems to display the list?
            /*Items = new ObservableCollection<LoginDetails>()
            {

            };

            //This seems to call the RestService
            _ = RestService.GetAllNewsAsync(list =>
            {
                foreach (LoginDetails data in list)
                {
                    Items.Add(data);

                }
            });*/
        }

        private void DoneTapped(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void ButtonTapped(object obj)
        {
            /*
            TappedItem = obj as LoginDetails;
            var dataForm = new UserEditPage
            {
                BindingContext = this
            };
            App.Current.MainPage.Navigation.PushModalAsync(dataForm);*/
        }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
    }
}
