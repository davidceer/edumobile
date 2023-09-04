using AcademiaNG.Helper;
using AcademiaNG.Models;
using AcademiaNG.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditPage : ContentPage
    {
        readonly UserEditViewModel mViewModel;
        public Command<object> DoneCommand { get; set; }

        public UserEditPage()
        {

        }
        public UserEditPage(IEnumerable<LoginDetails> source)
        {
            InitializeComponent();
            Title = "Edit Page";

            mViewModel = new UserEditViewModel(source);
            BindingContext = mViewModel;

            //https://parallelcodes.com/xamarin-forms-mvvm-button-click-pass-model-and-navigate-to-next-view/
            //https://parallelcodes.com/xamarin-forms-mvvm-how-to-call-web-api/
            //https://stackoverflow.com/questions/59192571/how-to-navigate-as-per-mvvm-architecture-in-xamarin-forms-without-using-any-fram
        }

        private async void ProfileUpdate_ClickedEvent(object sender, EventArgs e)
        {
            //access buttonclickhandler  
            var buttonClickHandler = (Button)sender;
            //access Parent Layout for Button  
            FlexLayout ParentStackLayout = (FlexLayout)buttonClickHandler.Parent;
            //access first Entry "UserID"  
            Entry userID = (Entry)ParentStackLayout.Children[1];
            //access second Entry "LoginID"  
            //Entry loginID = (Entry)ParentStackLayout.Children[2];
            //access first Entry "FirstName"  
            Entry firstName = (Entry)ParentStackLayout.Children[3];
            //access first Entry "MiddleName"  
            Entry middleName = (Entry)ParentStackLayout.Children[4];
            //access second Entry "LastName"  
            Entry lastName = (Entry)ParentStackLayout.Children[5];
            //access third Entry "UserEmail"  
            Entry userEmail = (Entry)ParentStackLayout.Children[6];
            //access third Entry "UserMobileNo"  
            Entry userMobileNo = (Entry)ParentStackLayout.Children[7];
            //access third Entry "UserDOB"  
            Entry userBirthDate = (Entry)ParentStackLayout.Children[8];

            List<KeyValuePair<string, string>> modelObj = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserID", userID.Text),
                //new KeyValuePair<string, string>("LoginID", loginID.Text),
                new KeyValuePair<string, string>("FirstName", firstName.Text),
                new KeyValuePair<string, string>("MiddleName", middleName.Text),
                new KeyValuePair<string, string>("LastName", lastName.Text),
                new KeyValuePair<string, string>("UserEmail", userEmail.Text),
                new KeyValuePair<string, string>("UserMobileNo", userMobileNo.Text),
                new KeyValuePair<string, string>("UserDob", userBirthDate.Text),
                new KeyValuePair<string, string>("tabCategory", "personal")
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
                List<LoginDetails> source = JsonConvert.DeserializeObject<List<LoginDetails>>(response, settings);
                IEnumerable<LoginDetails> ClassStudents = null;
                foreach (var data in source)
                {
                    ClassStudents = data.UserClassStudents;
                }
                await Navigation.PushModalAsync(new Dashboard(source, ClassStudents));
            }
        }
    }
}