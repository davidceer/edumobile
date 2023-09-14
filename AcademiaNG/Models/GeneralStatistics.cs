using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademiaNG.Models
{
    public class GeneralStatistics : IDbEntity
    {
        [PrimaryKey, AutoIncrement]

        [JsonProperty("stat_id")]
        public int StatID { get; set; }

        [JsonProperty("student_total")]
        public int StudentTotal { get; set; }

        [JsonProperty("teacher_total")]
        public int TeacherTotal { get; set; }

        [JsonProperty("course_total")]
        public int CourseTotal { get; set; }

        [JsonProperty("class_total")]
        public int ClassTotal { get; set; }

        public GeneralStatistics()
        {
        }
    }
}
