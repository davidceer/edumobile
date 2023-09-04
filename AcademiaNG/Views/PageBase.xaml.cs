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
    public partial class PageBase<TViewModel> : ContentPage, IView<TViewModel> where TViewModel : BaseViewModel, new()
    {
        public TViewModel ViewModel
        {
            get
            {
                return GetValue(BindingContextProperty) as TViewModel;
            }
            set
            {
                SetValue(BindingContextProperty, value);
            }
        }

        public object ViewResolver { get; private set; }

        #region <Events>

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ViewModel.OnModalNavigationRequest = HandleModalNavigationRequest;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.OnModalNavigationRequest = null;
        }
        #endregion
        /*
        async Task HandleModalNavigationRequest(BaseViewModel targetViewModel)
        {
            var targetView = ViewResolver.GetViewFor(targetViewModel);
            targetView.BindingContext = targetViewModel;
            await Navigation.PushModalAsync(new NavigationPage(targetView));
        }*/
    }
}