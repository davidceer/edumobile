using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaNG.Models
{
    [Table("Session")]
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int sch_session_id { get; set; }
        public string sch_session_name { get; set; }
        public string sch_session_description { get; set; }
        public string sch_session_start_date { get; set; }
        public string sch_session_end_date { get; set; }
        public DateTimeOffset? created_at { get; set; }
        [ForeignKey(typeof(User))]
        public int created_by { get; set; }
        public DateTimeOffset? updated_at { get; set; }
        [ForeignKey(typeof(User))]
        public int updated_by { get; set; }
        public int is_status { get; set; }

        [OneToMany]
        public List<User> Users { get; set; }
        public Session()
        {
        }
    }
}
