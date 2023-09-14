using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class StuCategory : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int stu_category_id { get; set; }
        public string stu_category_name { get; set; }
        [ForeignKey(typeof(Organization))]
        public int stu_category_org_id { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public Organization Organization { get; set; }

        public StuCategory()
        {
        }
    }
}
