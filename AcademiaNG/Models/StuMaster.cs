using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class StuMaster : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int stu_master_id { get; set; }
        [ForeignKey(typeof(StuInfo))]
        public int stu_master_stu_info_id { get; set; }
        [ForeignKey(typeof(User))]
        public int stu_master_user_id { get; set; }
        [ForeignKey(typeof(Nationality))]
        public int stu_master_nationality_id { get; set; }
        [ForeignKey(typeof(StuCategory))]
        public int stu_master_category_id { get; set; }
        [ForeignKey(typeof(Courses))]
        public int stu_master_course_id { get; set; }
        [ForeignKey(typeof(Batches))]
        public int stu_master_batch_id { get; set; }
        [ForeignKey(typeof(Classes))]
        public int stu_master_class_id { get; set; }
        [ForeignKey(typeof(StuAddress))]
        public int stu_master_stu_address_id { get; set; }
        [ForeignKey(typeof(Organization))]
        public int stu_master_org_id { get; set; }
        [MaxLength(11)]
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public Batches Batches { get; set; }
        public Courses Courses { get; set; }
        public Classes Classes { get; set; }
        public StuInfo StuInfo { get; set; }
        public Organization Organization { get; set; }
        public StuMaster()
        {
        }
    }
}
