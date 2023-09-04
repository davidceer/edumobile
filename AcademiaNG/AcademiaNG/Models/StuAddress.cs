using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class StuAddress
    {
        [PrimaryKey, AutoIncrement]
        public int stu_address_id { get; set; }
        public string stu_cadd { get; set; }
        [ForeignKey(typeof(City))]
        public int stu_cadd_city { get; set; }
        [ForeignKey(typeof(State))]
        public int stu_cadd_state { get; set; }
        [ForeignKey(typeof(Country))]
        public int stu_cadd_country { get; set; }
        public int stu_cadd_pincode { get; set; }
        public string stu_cadd_house_no { get; set; }
        public string stu_cadd_phone_no { get; set; }
        public string stu_padd { get; set; }
        [ForeignKey(typeof(City))]
        public int stu_padd_city { get; set; }
        [ForeignKey(typeof(State))]
        public int stu_padd_state { get; set; }
        [ForeignKey(typeof(Country))]
        public int stu_padd_country { get; set; }
        public int stu_padd_pincode { get; set; }
        public string stu_padd_house_no { get; set; }
        public string stu_padd_phone_no { get; set; }

        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }

        public StuAddress()
        {
        }
    }
}
