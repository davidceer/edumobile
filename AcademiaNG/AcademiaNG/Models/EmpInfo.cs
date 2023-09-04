using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class EmpInfo
    {
        [PrimaryKey, AutoIncrement]
        public int emp_info_id { get; set; }
        public string emp_unique_id { get; set; }
        public int emp_attendance_card_id { get; set; }
        public string emp_title { get; set; }
        public string emp_first_name { get; set; }
        public string emp_middle_name { get; set; }
        public string emp_last_name { get; set; }
        public string emp_name_alias { get; set; }
        public string emp_mother_name { get; set; }
        public string emp_gender { get; set; }
        public string emp_dob { get; set; }
        public string emp_religion { get; set; }
        public string emp_bloodgroup { get; set; }
        public string emp_joining_date { get; set; }
        public string emp_birthplace { get; set; }
        public string emp_email_id { get; set; }
        public string emp_maritalstatus { get; set; }
        public string emp_mobile_no { get; set; }
        public string emp_photo { get; set; }
        public string emp_languages { get; set; }
        [ForeignKey(typeof(BankMaster))]
        public int emp_info_bank_master_id { get; set; }
        public string emp_account_name { get; set; }
        public string emp_bankaccount_no { get; set; }
        public string emp_qualification { get; set; }
        public string emp_specialization { get; set; }
        public string emp_assigned_class { get; set; }
        public string emp_experience_year { get; set; }
        public int emp_experience_month { get; set; }
        public string emp_hobbies { get; set; }
        public string emp_reference { get; set; }
        public string emp_guardian_name { get; set; }
        public string emp_guardian_relation { get; set; }
        public string emp_guardian_qualification { get; set; }
        public string emp_guardian_occupation { get; set; }
        public string emp_guardian_income { get; set; }
        public string emp_guardian_homeadd { get; set; }
        public string emp_guardian_officeadd { get; set; }
        public string emp_guardian_mobile_no { get; set; }
        public string emp_guardian_phone_no { get; set; }
        public string emp_guardian_email_id { get; set; }
        [ForeignKey(typeof(EmpMaster))]
        public int emp_info_emp_master_id { get; set; }
        [ForeignKey(typeof(Organization))]
        public int emp_info_org_id { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", emp_first_name, emp_middle_name, emp_last_name); }
        }

        public BankMaster BankMaster { get; set; }
        public Organization Organization { get; set; }

        public EmpInfo()
        {
        }
    }
}
