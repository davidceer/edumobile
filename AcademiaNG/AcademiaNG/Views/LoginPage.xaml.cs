using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.ViewModels;
using Newtonsoft.Json;
//using System.Text.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private List<LoginDetails> source;

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            Username.ReturnCommand = new Command(() => Password.Focus());
            //Password.ReturnCommand = new Command(() => LoginCommand.Focus());
            var forgetpassword_tap = new TapGestureRecognizer();
            forgetpassword_tap.Tapped += Forgetpassword_tap_Tapped;
            forgetLabel.GestureRecognizers.Add(forgetpassword_tap);

            Username.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
            };
        }

        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> modelObj = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserLoginID", Username.Text),
                new KeyValuePair<string, string>("UserPassword", Password.Text)
            };
            //Constants.AcademiaNGUserViewData //The global uri
            RestService restService = new RestService();
            string response = await restService.PostAndGetUsingAPIAsync(modelObj);
            
            if (!string.IsNullOrEmpty(response))
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                response = response.TrimStart('\"');
                response = response.TrimEnd('\"');
                response = response.Replace("\\", "");
                source = JsonConvert.DeserializeObject<List<LoginDetails>>(response, settings);
                IEnumerable<LoginDetails> ClassStudents = null;
                foreach(var data in source)
                {
                    ClassStudents = data.UserClassStudents;
                }
                await Navigation.PushModalAsync(new Dashboard(source, ClassStudents));
            }
        }

        private void Forgetpassword_tap_Tapped(object sender, EventArgs e)
        {
            popupLoadingView.IsVisible = true;
        }

        private async void UserIdCheckEvent(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
            {
                await DisplayAlert("Alert", "Enter Username", "OK");
            }
            else
            {
                if (true)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                }
            }
        }

        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Enter Same Password";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Alert", " Enter Password", "OK");
            }
            else
            {
                try
                {
                    passwordView.IsVisible = false;
                    if (true)
                    {
                        await DisplayAlert("Password Updated", "User Data updated", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        async private void Button_Clicked_Login(object sender, EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = true;
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        async private void Button_Clicked_Logout(object sender, EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = false;
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new LoginPage();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }
    }
}