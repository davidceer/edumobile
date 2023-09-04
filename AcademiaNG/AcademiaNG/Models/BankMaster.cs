using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class BankMaster
    {
        [PrimaryKey, AutoIncrement]
        public int bank_master_id { get; set; }
        public string bank_master_name { get; set; }
        public string bank_alias { get; set; }
        [ForeignKey(typeof(Organization))]
        public int bank_org_id { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public Organization Organization { get; set; }

        public BankMaster()
        {
        }
    }
}
