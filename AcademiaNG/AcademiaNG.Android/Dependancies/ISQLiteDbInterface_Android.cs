﻿using AcademiaNG.Droid.Dependancies;
using AcademiaNG.Interfaces;
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

[assembly: Dependency(typeof(GetSQLiteConnnection))]
namespace AcademiaNG.Droid.Dependancies
{
    public class GetSQLiteConnnection : ISQLiteInterface
    {
        public GetSQLiteConnnection()
        {

        }
        public SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "UserDatabase.db3";
            //var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentPath, fileName);
            //var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(path, true);
            return connection;
        }
    }
}