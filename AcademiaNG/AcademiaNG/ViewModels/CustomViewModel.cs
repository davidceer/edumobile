using AcademiaNG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AcademiaNG.ViewModels
{
    public class CustomViewModel
    {
        public ICommand SaveCommand { set; get; }// save button
        public ObservableCollection<GroupedModel> Grouped { get; set; }// item source

        public CustomViewModel()
        {
            Grouped = new ObservableCollection<GroupedModel>();
            var Organizations = new ObservableCollection<GroupItemModel>();
            var People = new ObservableCollection<GroupItemModel>();// two groups
            Organizations.Add(new GroupItemModel("jqery", (item) =>
            {
                Grouped[0].Remove(item);// reomve action for each item
            }));
            Organizations.Add(new GroupItemModel("scripe", (item) =>
            {
                Grouped[0].Remove(item);
            }));
            People.Add(new GroupItemModel("first people", (item) =>
            {
                Grouped[1].Remove(item);
            }));

            Grouped.Add(new GroupedModel("Organizations", Organizations, (GroupItemModel) => {// add a new item named Organizations
                Grouped[0].Add(new GroupItemModel("Organization1", (item) =>
                {
                    Grouped[0].Remove(item);// remove the item from source
                }));

            }));
            Grouped.Add(new GroupedModel("People", People, (GroupItemModel) => {// add action in the footer
                Grouped[1].Add(new GroupItemModel("People1", (item) =>
                {
                    Grouped[1].Remove(item);
                }));
            }));

            SaveCommand = new Command(() =>
            {
                foreach (GroupedModel item in Grouped)
                {
                    foreach (var EachPeopeleAndOrganization in item)
                    {
                        Debug.WriteLine("{0}", EachPeopeleAndOrganization.Name);// display the stored value
                    }
                }
            });

        }
    }
}
