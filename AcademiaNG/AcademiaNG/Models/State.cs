using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("State")]
    public class State
    {
        [PrimaryKey, AutoIncrement]
        public int state_id { get; set; }
        public string state_name { get; set; }
        [ForeignKey(typeof(Country))]
        public int state_country_id { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        [OneToMany]
        public List<User> Users { get; set; }
        public Country Country { get; set; }
        public State()
        {
        }
    }
}
