using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class Courses : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        public int course_id { get; set; }
        public string course_name { get; set; }
        public string course_code { get; set; }
        public string course_alias { get; set; }
        [ForeignKey(typeof(CourseISCED))]
        public int course_isced { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        public List<User> Users { get; set; }
        public CourseISCED CourseISCED { get; set; }
        public Courses()
        {
        }
    }
}
