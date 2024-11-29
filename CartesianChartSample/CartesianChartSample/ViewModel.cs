using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartesianChartSample
{
    
    internal class ViewModel
    {
        public ObservableCollection<Model> CartesianData { get; set; }

        public ViewModel()
        {
            CartesianData = new ObservableCollection<Model>()
            {
                new Model { Name = "David", Height = 170, Weight = 65 },
                new Model { Name = "Michael", Height = 96, Weight = 48 },
                new Model { Name = "Steve", Height = 65, Weight = 45 },
                new Model { Name = "Joel", Height = 182, Weight = 60 },
                new Model { Name = "Bob", Height = 134, Weight = 50 },
                new Model { Name = "Thomas", Height = 177, Weight = 60 },
            };
        }
    };
}


