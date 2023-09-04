using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.Services;
using AcademiaNG.ViewModels;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage//, Behavior<Entry>
    {
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? @"https://api.academiang.info" : "@http://localhost/api"; //5037
        public static string truePathUrl = $"{BaseAddress}";
        //private readonly RegisterViewModel _viewModel;
        private List<LoginDetails> source;
        public RegisterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnAppearing();
        }

        async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(schoolNameEntry.Text)) || (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
             (string.IsNullOrWhiteSpace(phoneEntry.Text)) || (string.IsNullOrWhiteSpace(schoolAddressEntry.Text)))
            {
                await DisplayAlert("Enter Data", "All fields need to be filled", "OK");
            }
            else if (phoneEntry.Text.Length < 11 || phoneEntry.Text.Length > 11)
            {
                phoneEntry.Text = string.Empty;
                phoneWarLabel.Text = "Enter 11 digit Number";
                phoneWarLabel.TextColor = Color.IndianRed;
                phoneWarLabel.IsVisible = true;
            }
            else
            {                
                var modelObj = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Name", schoolNameEntry.Text),
                    new KeyValuePair<string, string>("Email", emailEntry.Text),
                    new KeyValuePair<string, string>("Phone", phoneEntry.Text.ToString()),
                    new KeyValuePair<string, string>("Address", schoolAddressEntry.Text)
                };
                try
                {
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
                        string SchoolName = null;
                        string UserLoginID = null;
                        string UserPassword = null;
                        string UserEmail = null;
                        foreach (var data in source)
                        {
                            SchoolName = data.Institution;
                            UserLoginID = data.LoginID;
                            UserPassword = data.Password;
                            UserEmail = data.UserEmail;
                        }
                        
                        EmailTest mailtext = new EmailTest();
                        /*
                        string[] recipient = { UserEmail };
                        List<string> recipientList = new List<string>(recipient);                        
                        TextPart textPart = new TextPart(MimeKit.Text.TextFormat.Html)
                        {
                            Text = @"Dear " + SchoolName + "," + Environment.NewLine + 
                            "You, or someone using your email address (" + UserEmail + ") has started registration on AcademiaNG" + Environment.NewLine +                    "Platform: AcademiaNG" + Environment.NewLine +
                            "<<<Your Login Parameters>>>" + Environment.NewLine +
                            "Username: " + UserLoginID + Environment.NewLine +
                            "Password: " + UserPassword + Environment.NewLine +
                            "Thanks for making it AcademiaNG. Please login again to start configuration"
                        };*/
                        string text =
                            @"Dear " + SchoolName + "," + Environment.NewLine +
                            "You, or someone using your email address (" + UserEmail + ") has started registration on AcademiaNG" + Environment.NewLine + "Platform: AcademiaNG" + Environment.NewLine +
                            "<<<Your Login Parameters>>>" + Environment.NewLine +
                            "Username: " + UserLoginID + Environment.NewLine +
                            "Password: " + UserPassword + Environment.NewLine +
                            "Thanks for making it AcademiaNG. Please login again to start configuration";

                        mailtext.SendEmailSMTP("AcademiaNG Registration", text, "davidceer@gmail.com", UserEmail);
                        //await mailtext.SendEmail("AcademiaNG Registration", textPart.ToString(), recipientList);
                        await Navigation.PushAsync(new LoginPage()); //ceers
                    }
                    else
                    {
                        warningLabel.IsVisible = false;
                        schoolNameEntry.Text = string.Empty;
                        emailEntry.Text = string.Empty;
                        phoneEntry.Text = string.Empty;
                        schoolAddressEntry.Text = string.Empty;
                    }
                }
                catch (HttpRequestException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        /*List<List<string>> mylist = listUser.Where(x => x != null)
                          .Select(x => new List<string> { x.text1, x.text2 }).ToList();*/
        public string GetDomainFromUrl(string url)
        {
            url = url.Replace("https://", "").Replace("http://", "").Replace("www.", ""); //Remove the prefix
            string[] fragments = url.Split('/');
            return fragments[0];
        }
    }

}