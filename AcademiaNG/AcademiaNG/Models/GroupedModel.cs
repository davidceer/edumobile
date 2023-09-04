using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AcademiaNG.Models
{
    public class GroupItemModel : INotifyPropertyChanged
    {
        string name;// entry text
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RemoveCommand { set; get; }

        Action<GroupItemModel> RemoveSelfAction { set; get; }
        public GroupItemModel(string name, Action<GroupItemModel> removeAction)
        {
            Name = name;
            RemoveSelfAction = removeAction;
            RemoveCommand = new Command(() =>
            {
                RemoveSelfAction(this);
            });
        }
        public GroupItemModel()
        {
            RemoveCommand = new Command(() =>
            {
                RemoveSelfAction(this);
            });
        }
        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
            get
            {
                return name;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class GroupedModel : ObservableCollection<GroupItemModel>
    {
        public ICommand AddCommand { set; get; }
        public string Name { get; set; }// GroupTitle, Organization or People

        public GroupedModel(string name, ObservableCollection<GroupItemModel> items, Action<GroupItemModel> AddNewOneAction) : base(items)
        {
            Name = name;
            AddCommand = new Command(() =>
            {
                AddNewOneAction(new GroupItemModel());
            });
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
