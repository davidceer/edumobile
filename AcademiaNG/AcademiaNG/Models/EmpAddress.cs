using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class EmpAddress
    {
        [PrimaryKey, AutoIncrement]
        public int emp_address_id { get; set; }
        public string emp_cadd { get; set; }
        [ForeignKey(typeof(City))]
        public int emp_cadd_city { get; set; }
        [ForeignKey(typeof(State))]
        public int emp_cadd_state { get; set; }
        [ForeignKey(typeof(Country))]
        public int emp_cadd_country { get; set; }
        public int emp_cadd_pincode { get; set; }
        public string emp_cadd_house_no { get; set; }
        public string emp_cadd_phone_no { get; set; }
        public string emp_padd { get; set; }
        [ForeignKey(typeof(City))]
        public int emp_padd_city { get; set; }
        [ForeignKey(typeof(State))]
        public int emp_padd_state { get; set; }
        [ForeignKey(typeof(Country))]
        public int emp_padd_country { get; set; }
        public int emp_padd_pincode { get; set; }
        public string emp_padd_house_no { get; set; }
        public string emp_padd_phone_no { get; set; }

        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }

        public EmpAddress()
        {
        }
    }
}
