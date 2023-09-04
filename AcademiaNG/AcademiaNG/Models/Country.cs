using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("Country")]
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int country_id { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        [OneToMany]
        public List<User> Users { get; set; }
        public Country()
        {
        }
    }
}
