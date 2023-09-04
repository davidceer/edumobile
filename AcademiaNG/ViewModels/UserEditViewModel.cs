using AcademiaNG.Models;
using AcademiaNG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class UserEditViewModel : BaseViewModel
    {
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        private IEnumerable<LoginDetails> _items;
        public IEnumerable<LoginDetails> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public UserEditViewModel()
        {
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command<object>(Update);
        }

        public UserEditViewModel(IEnumerable<LoginDetails> itemSource)
        {
            Items = itemSource;
        }

        private void Update(object obj)
        {
        }

        private void Delete()
        {
        }
    }
}
