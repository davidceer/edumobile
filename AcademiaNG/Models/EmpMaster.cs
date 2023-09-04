using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class EmpMaster
    {
        [PrimaryKey, AutoIncrement]
        public int emp_master_id { get; set; }
        [ForeignKey(typeof(EmpInfo))]
        public int emp_master_emp_info_id { get; set; }
        [ForeignKey(typeof(User))]
        public int emp_master_user_id { get; set; }
        [ForeignKey(typeof(EmpDepartment))]
        public int emp_master_department_id { get; set; }
        [ForeignKey(typeof(EmpDesignation))]
        public int emp_master_designation_id { get; set; }
        [ForeignKey(typeof(EmpCategory))]
        public int emp_master_category_id { get; set; }
        [ForeignKey(typeof(Nationality))]
        public int emp_master_nationality_id { get; set; }
        [ForeignKey(typeof(EmpAddress))]
        public int emp_master_emp_address_id { get; set; }
        [ForeignKey(typeof(State))]
        public int emp_master_state_id { get; set; }
        [ForeignKey(typeof(City))]
        public int emp_master_city_id { get; set; }
        public int emp_master_status_id { get; set; }
        [ForeignKey(typeof(Organization))]
        public int emp_master_org_id { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public Nationality Nationality { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public EmpAddress EmpAddress { get; set; }
        public EmpCategory EmpCategory { get; set; }
        public EmpDepartment EmpDepartment { get; set; }
        public EmpDesignation EmpDesignation { get; set; }
        public EmpInfo EmpInfo { get; set; }
        public Organization Organization { get; set; }
        public EmpMaster()
        {
        }
    }
}
