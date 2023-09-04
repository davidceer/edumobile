using AcademiaNG.Models;
using AcademiaNG.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademiaNG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TestPage : ContentPage
    {
        readonly TestViewModel viewModel;

        public TestPage(TestViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TestPage()
        {
            InitializeComponent();

            var item = new TestModel
            {
                WTNNumber = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new TestViewModel(item);
            BindingContext = viewModel;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }
    }
}