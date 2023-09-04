using AcademiaNG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        TestModel item;
        public TestModel Item
        {
            get
            {
                return item;
            }
            set
            {
                if (item != value)
                {
                    item = value;
                    NotifyPropertyChanged("Item");
                }
            }

        }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public TestViewModel(TestModel item)
        {
            var Title = item?.WTNNumber;
            Item = item;


            DeleteCommand = new Command(() => {
                //...
            });

            EditCommand = new Command(() => {
                Item.WTNNumber = "new item";
                Item.Description = "new Description";

                // do something when click the edit button
            });

        }



    }
}
