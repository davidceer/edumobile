using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AcademiaNG.Models
{
    public class StuInfo : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("stu_info_id")]
        public int StuInfoID { get; set; }
        [JsonProperty("stu_unique_id")]
        public string StuUniqueID { get; set; }
        [JsonProperty("stu_title")]
        public string StuTitle { get; set; }
        [JsonProperty("stu_first_name")]
        public string StuFirstname { get; set; }
        [JsonProperty("stu_middle_name")]
        public string StuMiddlename { get; set; }
        [JsonProperty("stu_last_name")]
        public string StuLastname { get; set; }
        /*public string stu_gender { get; set; }
        public string stu_dob { get; set; }
        public string stu_email_id { get; set; }
        public string stu_bloodgroup { get; set; }
        public string stu_birthplace { get; set; }
        public string stu_religion { get; set; }
        public string stu_admission_no { get; set; }
        public string stu_admission_date { get; set; }*/
        [JsonProperty("stu_photo")]
        public ImageSource StuPhoto { get; set; }
        /*public string stu_languages { get; set; }
        public string stu_mobile_no { get; set; }
        public int stu_info_stu_master_id { get; set; }
        [ForeignKey(typeof(Organization))]
        public int stu_info_org_id { get; set; }*/

        public Organization Organization { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", StuFirstname, StuMiddlename, StuLastname); }
        }
        public StuInfo()
        {
        }

        private readonly string arg1;
        private readonly string arg2;
        public StuInfo(string a, string b)
        {
            this.arg1 = a;
            this.arg2 = b;
        }
    }
}
