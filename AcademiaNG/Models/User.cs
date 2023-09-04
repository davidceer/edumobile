using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        [JsonProperty("user_login_id")]
        public string UserLoginID { get; set; }

        [JsonProperty("user_password")]
        public string UserPassword { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [ForeignKey(typeof(Organization))]
        [JsonProperty("user_org_id")]
        public int UserOrgID { get; set; }

        [ForeignKey(typeof(Organization))]
        public int UserSetID { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        [ForeignKey(typeof(User))]
        public int CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
        [ForeignKey(typeof(User))]
        public int UpdatedBy { get; set; }

        public int IsStatus { get; set; }

        [OneToMany]
        public Organization Organization { get; set; }
        public User()
        {
        }
    }
}
