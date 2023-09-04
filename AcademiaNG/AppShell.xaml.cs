using AcademiaNG.ViewModels;
using AcademiaNG.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AcademiaNG
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

    }
}
