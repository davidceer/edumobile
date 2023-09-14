using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class EmpDesignation : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int emp_designation_id { get; set; }
        public string emp_designation_name { get; set; }
        public string emp_designation_alias { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public EmpDesignation()
        {
        }
    }
}
