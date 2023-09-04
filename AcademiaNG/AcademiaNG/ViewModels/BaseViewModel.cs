using AcademiaNG.Models;
using AcademiaNG.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /*
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }*/

        //readonly string title = string.Empty;
        /*
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }*/

        public string Title
        {
            get { return GetProperty<string>("title"); }
            set { SetProperty(value, "title"); }
        }

        protected bool SetProperty<T>(T value,
         [CallerMemberName] string propertyName = "",
         Action onChanged = null)
        {
            if (!Application.Current.Properties.ContainsKey(propertyName))
            {
                Application.Current.Properties.Add(propertyName, default(T));
            }

            var oldValue = GetProperty<T>(propertyName);
            if (EqualityComparer<T>.Default.Equals(oldValue, value))
                return false;

            Application.Current.Properties[propertyName] = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /*
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }*/

        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (!Application.Current.Properties.ContainsKey(propertyName))
            {
                return default;
            }
            else
            {
                return (T)Application.Current.Properties[propertyName];
            }
        }
        public Func<BaseViewModel, Task> OnModalNavigationRequest { get; set; }

        public async Task NavigateToModal<TViewModel>(TViewModel targetViewModel) where TViewModel : BaseViewModel
        {
            await OnModalNavigationRequest?.Invoke(targetViewModel);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
