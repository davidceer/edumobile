using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    public class Classes : IDbEntity
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("class_id")]
        public int ClassID { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("class_code")]
        public string ClassCode { get; set; }

        [JsonProperty("class_details")]
        public string ClassDetails { get; set; }

        [JsonProperty("total_students")]
        public int TotalStudents { get; set; }

        public List<User> Users { get; set; }
        public CourseISCED CourseISCED { get; set; }

        public Classes()
        {
        }
    }
}
