using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class Batches
    {
        [PrimaryKey, AutoIncrement]
        public int batch_id { get; set; }
        public string batch_name { get; set; }
        public string batch_alias { get; set; }
        [ForeignKey(typeof(CourseISCED))]
        public int batch_course_isced_id { get; set; }
        [ForeignKey(typeof(Courses))]
        public int batch_course_id { get; set; }
        [ForeignKey(typeof(Classes))]
        public int batch_class_id { get; set; }
        [ForeignKey(typeof(Organization))]
        public int batch_org_id { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public CourseISCED CourseISCED { get; set; }
        public Courses Courses { get; set; }
        public Classes Classes { get; set; }
        public Organization Organization { get; set; }
        public Batches()
        {
        }
    }
}
