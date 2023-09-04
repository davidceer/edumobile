using AcademiaNG.Models;
using AcademiaNG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private LoginDetails _tappedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command<object> TapCommand { get; set; }
        public Command<object> DoneCommand { get; set; }

        public LoginDetails TappedItem
        {
            get => _tappedItem;
            set
            {
                _tappedItem = value;
                OnPropertyChanged("TappedItem");
            }
        }

        public ContactsViewModel()
        {
            TapCommand = new Command<object>(ButtonTapped);
            DoneCommand = new Command<object>(DoneTapped);
        }

        private void DoneTapped(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void ButtonTapped(object obj)
        {
            /*
            TappedItem = obj as LoginDetails;
            UserEditPage dataForm = new UserEditPage
            {
                BindingContext = this
            };
            App.Current.MainPage.Navigation.PushAsync(dataForm);*/
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
