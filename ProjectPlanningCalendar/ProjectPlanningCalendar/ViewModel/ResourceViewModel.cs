using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanningCalendar
{
    public class ResourceViewModel
    {
        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceViewModel" /> class.
        /// </summary>
        public ResourceViewModel()
        {
            this.colors = new List<Brush>();
            this.Events = new ObservableCollection<Task>();
            this.Resources = new ObservableCollection<object>();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
            this.AddResourcesColors();  
            this.AddSchedulerResources();
            this.BookingAppointments();
        }

        /// <summary>
        /// Method to add resources or employees to the scheduler.
        /// </summary>
        private void AddSchedulerResources()
        {
            Random random = new Random();
            List<string> employeeNames = new List<string>
            {
                "Johnny",
                "James William",
                "Kinsley Elena",
                "Adeline Ruby",
                "Daniel",
                "Emilia",
                "Robert",
                "Sophia",
                "Stephen",
            };

            for (int i = 0; i < 9; i++)
            {
                Employee employees = new Employee();
                employees.Name = employeeNames[i];
                employees.Background = this.colors[random.Next(0, 9)];
                employees.Foreground = (employees.Background as SolidColorBrush)?.Color.GetLuminosity() > 0.7 ? Colors.Black : Colors.White;
                employees.Id = i.ToString();

                if (employees.Name == "Johnny")
                {
                    employees.ImageName = "people8.png";
                }
                else if (employees.Name == "Stephen")
                {
                    employees.ImageName = "people1.png";
                }
                else if (employees.Name == "Robert")
                {
                    employees.ImageName = "people9.png";
                }
                else if (employees.Name == "Sophia")
                {
                    employees.ImageName = "people2.png";
                }
                else if (employees.Name == "Emilia")
                {
                    employees.ImageName = "people7.png";
                }
                else if (employees.Name == "Daniel")
                {
                    employees.ImageName = "people3.png";
                }
                else if (employees.Name == "Adeline Ruby")
                {
                    employees.ImageName = "people4.png";
                }
                else if (employees.Name == "Kinsley Elena")
                {
                    employees.ImageName = "people5.png";
                }
                else if (employees.Name == "James William")
                {
                    employees.ImageName = "people6.png";
                }
                //// Bind this custom resources.
                Resources?.Add(employees);
            }
        }


        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<Task>? Events { get; set; }

        public ObservableCollection<object>? Resources { get; set; }

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }


        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        internal void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();
            DateTime date;
            DateTime today = DateTime.Now;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            List<string> currentDayMeetings = new List<string>
            {
                "General Meeting",
                "Plan Execution",
                "Project Plan",
                "Consulting",
                "Performance Check",
                "Yoga Therapy",
                "Plan Execution",
                "Project Plan",
                "Consulting",
                "Performance Check"
            };

            List<int> startHours = new List<int>
            {
                0,
                12,
                12
            };

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                for (int res = 0; res < 2; res++)
                {
                    Employee? resource = this.Resources[randomTime.Next(this.Resources.Count)] as Employee;
                    if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                    {
                        for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 3; additionalAppointmentIndex++)
                        {
                            Task meeting = new Task();
                            meeting.From = new DateTime(date.Year, date.Month, date.Day, startHours[randomTime.Next(0, 2)], 0, 0);
                            meeting.To = meeting.From.AddHours(12);
                            meeting.EventName = currentDayMeetings[randomTime.Next(9)];
                            meeting.Background = this.colors[randomTime.Next(9)];
                            meeting.IsAllDay = false;
                            meeting.StartTimeZone = TimeZoneInfo.Local;
                            meeting.EndTimeZone = TimeZoneInfo.Local;
                            ObservableCollection<object> resources = new ObservableCollection<object>();
                            if (resource != null && resource.Id != null)
                            {
                                resources.Add(resource.Id);
                            }
                            meeting.Resources = resources;
                            this.Events?.Add(meeting);
                        }
                    }
                    else
                    {
                        Task meeting = new Task();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                        meeting.To = meeting.From.AddDays(2).AddHours(4);
                        meeting.EventName = currentDayMeetings[randomTime.Next(9)];
                        meeting.Background = this.colors[randomTime.Next(9)];
                        meeting.IsAllDay = true;
                        meeting.StartTimeZone = TimeZoneInfo.Local;
                        meeting.EndTimeZone = TimeZoneInfo.Local;
                        ObservableCollection<object> resources = new ObservableCollection<object>();
                        if (resource != null && resource.Id != null)
                        {
                            resources.Add(resource.Id);
                        }
                        meeting.Resources = resources;
                        this.Events?.Add(meeting);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Employee? resourceView = this.Resources[i] as Employee;
                //// Adding Span appointments
                Task meeting = new Task();
                meeting.From = today.Date.AddDays(1);
                meeting.To = today.Date.AddDays(8);
                meeting.EventName = currentDayMeetings[randomTime.Next(9)];
                meeting.Background = this.colors[randomTime.Next(10)];
                ObservableCollection<object> meetingResources = new ObservableCollection<object>();
                if (resourceView != null && resourceView.Id != null)
                {
                    meetingResources.Add(resourceView.Id);
                }
                meeting.Resources = meetingResources;

                Task planning = new Task();
                planning.EventName = currentDayMeetings[randomTime.Next(9)];
                planning.From = today.Date.AddDays(-6);
                planning.To = today.Date;
                planning.Background = this.colors[randomTime.Next(10)];
                ObservableCollection<object> planningResources = new ObservableCollection<object>();
                if (resourceView != null && resourceView.Id != null)
                {
                    planningResources.Add(resourceView.Id);
                }
                planning.Resources = planningResources;

                Task consulting = new Task();
                consulting.EventName = currentDayMeetings[randomTime.Next(9)];
                consulting.From = today.Date.AddHours(23);
                consulting.To = today.Date.AddDays(1).AddHours(2);
                consulting.IsAllDay = false;
                consulting.Background = this.colors[randomTime.Next(10)];
                ObservableCollection<object> consultingResources = new ObservableCollection<object>();
                if (resourceView != null && resourceView.Id != null)
                {
                    consultingResources.Add(resourceView.Id);
                }
                consulting.Resources = consultingResources;

                this.Events?.Add(meeting);
                this.Events?.Add(planning);
                this.Events?.Add(consulting);
            }
        }

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>
            {
                new Point(9, 11),
                new Point(12, 14),
                new Point(15, 17)
            };

            return randomTimeCollection;
        }

        /// <summary>
        /// method to add colors for task and scheduler resources.
        /// </summary>
        private void AddResourcesColors()
        {
            this.colors = new List<Brush>
            {
                Color.FromArgb("#FF8B1FA9"),
                Color.FromArgb("#FFD20100"),
                Color.FromArgb("#FFFC571D"),
                Color.FromArgb("#FF36B37B"),
                Color.FromArgb("#FF3D4FB5"),
                Color.FromArgb("#FF3D4FB5"),
                Color.FromArgb("#FF636363"),
                Color.FromArgb("#FF636363"),
                Color.FromArgb("#FF01A1EF"),
                Color.FromArgb("#FF0F8644"),
                Color.FromArgb("#FF00ABA9")
            };
        }

    }
}
