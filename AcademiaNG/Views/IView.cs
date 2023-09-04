using AcademiaNG.ViewModels;

namespace AcademiaNG.Views
{
    internal interface IView<TViewModel> where TViewModel : BaseViewModel, new()
    {
    }
}