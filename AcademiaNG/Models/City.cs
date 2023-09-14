using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("City")]
    public class City : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int city_id { get; set; }
        public string city_name { get; set; }

        [ForeignKey(typeof(State))]
        public int city_state_id { get; set; }

        [ForeignKey(typeof(Country))]
        public int city_country_id { get; set; }

        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        [OneToMany]
        public List<User> Users { get; set; }
        [OneToOne]
        public State State { get; set; }
        [OneToOne]
        public Country Country { get; set; }
        [OneToMany]
        public List<Organization> Organizations { get; set; }

        public City()
        {
        }

        public City(string _name)
        {
            city_name = _name;
        }
    }
}
