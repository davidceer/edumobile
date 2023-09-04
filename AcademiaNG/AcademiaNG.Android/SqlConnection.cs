using AcademiaNG.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnection))]

namespace AcademiaNG.Droid
{
    public class SqlConnection
    {
        public SQLiteAsyncConnection Connection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); //MyDocuments
            var path = Path.Combine(documentsPath, "AcademiaSQLite.sqldb");

            if (!Directory.Exists(path))
            {
                try
                {

                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
            }
            return new SQLiteAsyncConnection(path);
        }
    }
}