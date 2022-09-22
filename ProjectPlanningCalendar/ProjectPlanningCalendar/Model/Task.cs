using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanningCalendar
{
    public class Task
    {
        public Task()
        {
            this.From = DateTime.Now;
            this.To = DateTime.Now;
            this.TaskName = string.Empty;
            this.Background = Brush.Transparent;
            this.RecurrenceRule = string.Empty;
            this.Resources = new ObservableCollection<object>();
        }

        /// <summary>
        /// Gets or sets the value to display the start date.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the value to display the end date.
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the value to display the subject.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or sets the value to display the background.
        /// </summary>
        public Brush Background { get; set; }

        /// <summary>
        /// Gets or sets the value to display the RRule.
        /// </summary>
        public string RecurrenceRule { get; set; }

        /// <summary>
        /// Gets or sets the value to display the resource collection.
        /// </summary>
        public ObservableCollection<object> Resources { get; set; }

        /// <summary>
        /// Gets or sets the value to all day appointments.
        /// </summary>
        public bool IsAllDay { get; set; }
    }
}
