using AcademiaNG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace AcademiaNG.ViewModels
{
    public class ChartsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public List<Classes> ClassData { get; set; }
        public ObservableCollection<GeneralStatistics> Statistic { get; set; }

        int hue, saturation, luminosity;
        Color color;

        public int Hue
        {
            set
            {
                if (hue != value)
                {
                    hue = value;
                    OnPropertyChanged("Hue");
                    SetNewColor();
                }
            }
            get
            {
                return hue;
            }
        }

        public int Saturation
        {
            set
            {
                if (saturation != value)
                {
                    saturation = value;
                    OnPropertyChanged("Saturation");
                    SetNewColor();
                }
            }
            get
            {
                return saturation;
            }
        }

        public int Luminosity
        {
            set
            {
                if (luminosity != value)
                {
                    luminosity = value;
                    OnPropertyChanged("Luminosity");
                    SetNewColor();
                }
            }
            get
            {
                return luminosity;
            }
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");

                    Hue = this.Hue;
                    Saturation = this.Saturation;
                    Luminosity = this.Luminosity;
                }
            }
            get
            {
                return color;
            }
        }

        void SetNewColor()
        {
            Color = Color.FromArgb(Hue, Saturation, Luminosity);
        }

        public ChartsViewModel()
        {
        }

        public ChartsViewModel(IEnumerable<LoginDetails> source)
        {
            var children = new List<Classes>();
            foreach (var child in source)
            {
                children.Add(new Classes
                {
                    ClassName = child.StudentClass,
                    TotalStudents = child.UserID
                });
            }

            ClassData = new List<Classes>()
            {
                new Classes { ClassName = "PRY 1", TotalStudents = 180 },
                new Classes { ClassName = "PRY 2", TotalStudents = 170 },
                new Classes { ClassName = "PRY 3", TotalStudents = 160 },
                new Classes { ClassName = "PRY 4", TotalStudents = 160 },
                new Classes { ClassName = "PRY 5", TotalStudents = 160 },
                new Classes { ClassName = "PRY 6", TotalStudents = 182 }
            };

            Statistic = new ObservableCollection<GeneralStatistics>()
            {
                new GeneralStatistics { StudentTotal = 180 },
                new GeneralStatistics { TeacherTotal = 170 },
                new GeneralStatistics { CourseTotal = 160 },
                new GeneralStatistics { ClassTotal = 160 }
            };

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
