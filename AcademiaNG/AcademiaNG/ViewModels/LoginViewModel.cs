using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<LoginDetails> items;

        public ObservableCollection<LoginDetails> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public Action DisplayInvalidLoginPrompt;
        
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            Title = "DashBoard";
            //This seems to display the list?
            Items = new ObservableCollection<LoginDetails>()
            {

            };

            //This seems to call the ApiService
            _ = RestService.GetAllNewsAsync(list =>
            {
                foreach (LoginDetails item in list)
                {
                    Items.Add(item);

                }
            });
            //SubmitCommand = new Command(async () => await OnSubmit());
        }
        /*
        public async Task OnSubmit()
        {
            await NavigateToModal<DashboardViewModel>(new DashboardViewModel());
        }*/
    }
}
