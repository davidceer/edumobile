using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
//using System.Text.Json.Serialization;

namespace AcademiaNG.Models
{
    [Table("LoginDetails")]
    public class LoginDetails : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("org_id")]
        public int OrgID { get; set; }
        [MaxLength(60)]
        [JsonProperty("org_name")]
        public string Institution { get; set; }

        [MaxLength(10)]
        [JsonProperty("org_code")]
        public string Code { get; set; }

        [JsonProperty("full_name")]
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    NotifyPropertyChanged("FullName");
                }
            }
        }

        [JsonProperty("user_first_name")]
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        [JsonProperty("user_middle_name")]
        private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    NotifyPropertyChanged("MiddleName");
                }
            }
        }

        [JsonProperty("user_last_name")]
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        [JsonProperty("user_email_id")]
        private string userEmail;
        public string UserEmail
        {
            get { return userEmail; }
            set
            {
                if (userEmail != value)
                {
                    userEmail = value;
                    NotifyPropertyChanged("UserEmail");
                }
            }
        }

        [JsonProperty("batch_name")]
        private string studentClass;
        public string StudentClass
        {
            get { return studentClass; }
            set
            {
                if (studentClass != value)
                {
                    studentClass = value;
                    NotifyPropertyChanged("StudentClass");
                }
            }
        }

        [JsonProperty("stu_admission_no")]
        public string StudentAdmission { get; set; }

        [JsonProperty("stu_seat_no")]
        public string StudentSeatNo { get; set; }

        [JsonProperty("user_dob")]
        public string UserDob { get; set; }

        [JsonProperty("user_gender")]
        public string UserGender { get; set; }

        [JsonProperty("user_mobile_no")]
        public string UserMobileNo { get; set; }

        [JsonProperty("class_students")]
        public IEnumerable<LoginDetails> UserClassStudents { get; set; }

        [JsonProperty("org_photo")]
        public string Photo { get; set; }

        [JsonProperty("section_id")]
        public int Section { get; set; }

        [JsonProperty("session_id")]
        public int Session { get; set; }

        [MaxLength(12)]
        [JsonProperty("user_login_id")]
        public string LoginID { get; set; }

        [MaxLength(12)]
        [JsonProperty("user_password")]
        public string Password { get; set; }

        [JsonProperty("user_id")]
        public int UserID { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
