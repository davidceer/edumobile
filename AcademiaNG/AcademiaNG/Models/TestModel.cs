using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcademiaNG.Models
{
    public class TestModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        string wTNNumber;
        public string WTNNumber
        {

            get
            {
                return wTNNumber;
            }
            set
            {
                if (wTNNumber != value)
                {
                    wTNNumber = value;
                    NotifyPropertyChanged("WTNNumber");
                }
            }

        }

        string description;
        public string Description
        {

            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }

        }
    }
}