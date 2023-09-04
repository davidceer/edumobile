using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("Organization")]
    public class Organization
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("org_id")]
        public int OrgID { get; set; }
        [MaxLength(60)]
        [JsonProperty("org_name")]
        public string Name { get; set; }

        [MaxLength(10)]
        [JsonProperty("org_code")]
        public string Code { get; set; }

        [JsonProperty("org_email")]
        public string Email { get; set; }

        [MaxLength(12)]
        [JsonProperty("org_phone")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [JsonProperty("org_address_line1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [JsonProperty("org_address_line2")]
        public string Address2 { get; set; }

        [MaxLength(30)]
        [JsonProperty("org_slogan")]
        public string Slogan { get; set; }

        [JsonProperty("org_alias")]
        public string Alias { get; set; }

        [JsonProperty("org_approval_no")]
        public string Approval { get; set; }

        [ForeignKey(typeof(City))]
        public int CityID { get; set; }

        [ForeignKey(typeof(State))]
        public int StateID { get; set; }

        [ForeignKey(typeof(Country))]
        public int CountryID { get; set; }

        public string SelectedCourse { get; set; }
        public string Website { get; set; }

        [ForeignKey(typeof(Section))]
        public int SchoolSection { get; set; }

        [ForeignKey(typeof(Session))]
        public int SchoolSession { get; set; }

        public string Photo { get; set; }

        public string Logo { get; set; }

        public string LogoType { get; set; }

        public string StudentPrefix { get; set; }

        public string EmployeePrefix { get; set; }

        public string DateFounded { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        [ForeignKey(typeof(User))]
        public int CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        [ForeignKey(typeof(User))]
        public int UpdatedBy { get; set; }

        public int IsStatus { get; set; }

        [OneToMany]
        public List<User> Users { get; set; }
        [OneToOne]
        public City City { get; set; }
        [OneToOne]
        public State State { get; set; }
        [OneToOne]
        public Country Country { get; set; }
        [OneToOne]
        public Section Section { get; set; }
        [OneToOne]
        public Session Session { get; set; }

        public Organization()
        {
        }

        public Organization(string _name, string _slogan, string _alias, string _code, string _apprNo,
            string _addr1, string _addr2, int _city, int _state, int _country, string _email, string _phone, 
            string _courseOffer, string _website, int _sec, int _ses, string _photo, string _logo, 
            string _logoType, string _stuPrefix, string _empPrefix, string _date)
        {
            Name = _name;
            Slogan = _slogan;
            Alias = _alias;
            Code = _code;
            Approval = _apprNo;
            Address1 = _addr1;
            Address2 = _addr2;
            Email = _email;
            Phone = _phone;
            CityID = _city;
            StateID = _state;
            CountryID = _country;
            SelectedCourse = _courseOffer;
            Website = _website;
            SchoolSection = _sec;
            SchoolSession = _ses;
            Photo = _photo;
            Logo = _logo;
            LogoType = _logoType;
            StudentPrefix = _stuPrefix;
            EmployeePrefix = _empPrefix;
            DateFounded = _date;
        }
    }
}
