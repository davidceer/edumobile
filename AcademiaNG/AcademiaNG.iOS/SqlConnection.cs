using AcademiaNG.iOS;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnection))]

namespace AcademiaNG.iOS
{
    public class SqlConnection
    {
        public SQLiteAsyncConnection Connection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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