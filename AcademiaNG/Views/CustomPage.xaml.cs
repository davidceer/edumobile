using AcademiaNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPage : ContentPage
    {
        //readonly CustomViewModel _viewModel;
        public CustomPage()
        {
            InitializeComponent();
            //BindingContext = _viewModel = new CustomViewModel();
        }
    }
}