using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanningCalendar
{
    public class Employee
    {
        public Employee()
        {
            this.Name = string.Empty;
            this.Id = this.GetHashCode();
            this.Background = Brush.Transparent;
            this.Foreground = Brush.Black;
            this.ImageName = string.Empty;
        }

        public string Name { get; set; }

        public object? Id { get; set; }

        public Brush Background { get; set; }

        public Brush Foreground { get; set; }

        public string ImageName { get; set; }
    }
}
