using System.Collections.ObjectModel;

namespace ProjectPlanningCalendar
{
    public class Task
    {
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
        public string TaskName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value to display the background.
        /// </summary>
        public Brush? Background { get; set; }

        /// <summary>
        /// Gets or sets the value to display the RRule.
        /// </summary>
        public string RecurrenceRule { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value to display the resource collection.
        /// </summary>
        public ObservableCollection<object> Resources { get; set; } = new ObservableCollection<object>();

        /// <summary>
        /// Gets or sets the value to all day appointment.
        /// </summary>
        public bool IsAllDay { get; set; }
    }
}
