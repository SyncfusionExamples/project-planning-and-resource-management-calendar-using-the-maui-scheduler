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
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<Task> Tasks { get; set; }

        public ObservableCollection<object> Resources { get; set; }

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> resourceColors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceViewModel" /> class.
        /// </summary>
        public ResourceViewModel()
        {
            this.resourceColors = new List<Brush>();
            this.Tasks = new ObservableCollection<Task>();
            this.Resources = new ObservableCollection<object>();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
            this.AddResourcesColors();
            this.AddSchedulerResources();
            this.PlanTasks();
        }

        /// <summary>
        /// Method to add resources or employees to the scheduler.
        /// </summary>
        private void AddSchedulerResources()
        {
            Random random = new Random();
            List<string> employeeNames = new List<string>
            {
                  "Robert", "Sophia", "Emilia" , "Stephen",  "James William", "Johnny", "Daniel", "Adeline Ruby","Kinsley Elena",
            };

            for (int i = 0; i < 9; i++)
            {
                Employee employees = new Employee();
                employees.Name = employeeNames[i];
                employees.Background = this.resourceColors[random.Next(this.resourceColors.Count)];
                employees.Foreground = (employees.Background as SolidColorBrush)?.Color.GetLuminosity() > 0.7 ? Colors.Black : Colors.White;
                employees.Id = i + 1;

                if (employees.Name == "Robert")
                {
                    employees.ImageName = "people9.png";
                    employees.Role = "Project manager";
                }
                else if (employees.Name == "Sophia")
                {
                    employees.ImageName = "people2.png";
                    employees.Role = "Team lead";
                }
                else if (employees.Name == "Emilia")
                {
                    employees.ImageName = "people7.png";
                    employees.Role = "Developer";
                }
                else if (employees.Name == "Stephen")
                {
                    employees.ImageName = "people1.png";
                    employees.Role = "Developer";
                }
                else if (employees.Name == "James William")
                {
                    employees.ImageName = "people6.png";
                    employees.Role = "Developer";
                }
                else if (employees.Name == "Daniel")
                {
                    employees.ImageName = "people3.png";
                    employees.Role = "Tester";
                }
                else if (employees.Name == "Johnny")
                {
                    employees.ImageName = "people8.png";
                    employees.Role = "Tester";
                }
                else if (employees.Name == "Adeline Ruby")
                {
                    employees.ImageName = "people4.png";
                    employees.Role = "Support Engineer";
                }
                else if (employees.Name == "Kinsley Elena")
                {
                    employees.ImageName = "people5.png";
                    employees.Role = "Content writer";
                }
                //// Bind this custom resources.
                Resources.Add(employees);
            }
        }

        /// <summary>
        /// Method to create tasks.
        /// </summary>
        private void PlanTasks()
        {
            Random random = new Random();
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);

            List<string> managerTasks = new List<string> { "Project goal", "Project plan", "API review", "Project final review" };

            List<string> teamleadTasks = new List<string> { "Project requirments", "Project design", "API analysis", "Feature review", "Support coordinate", "Tech Blog", "Sprint plan", "Sprint review", "Sprint retrospect" };

            List<string> supportTasks = new List<string> { "Customer meeting", "User gauide documentation", "Knowbase document" };

            List<string> developmentTasks = new List<string> { "Base for calendar", "Implement month calendar", "Implement year calendar", "Implement decade calendar", "Implement century calendar", "Implement date selection", "Implement range selection", "Implement blackout dates", "Implement multiple selection" };

            List<string> testingTasks = new List<string> { "Unit testing", "UI automation", "Performance testing", "Memory leak testing", "Feature testing", "Demos testing", "Automate test cases", "Peer testing", "Exploratory testing", "Sanity testing" };

            List<string> documentationTasks = new List<string> { "User guide documentation", "Feature tour", "Whats new", "Road map", "Knowledge base", "Technical review", "Content review", };

            for (DateTime date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Monday)
                    continue;

                for (int i = 0; i < 9; i++)
                {
                    Employee resource = this.Resources[i] as Employee;
                    DateTime startDate = new DateTime(date.Year, date.Month, date.Day, random.Next(9, 18), 0, 0);
                    Task meeting = new Task();
                    meeting.From = startDate;
                    meeting.To = startDate.AddDays(4).AddHours(1);
                    meeting.Background = this.resourceColors[random.Next(resourceColors.Count)];
                    meeting.Resources = new ObservableCollection<object>() { resource.Id };
                    meeting.IsAllDay = true;

                    if (string.Equals(resource.Role, "Project manager"))
                    {
                        meeting.TaskName = managerTasks[random.Next(managerTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Team lead"))
                    {
                        meeting.TaskName = teamleadTasks[random.Next(teamleadTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Developer"))
                    {
                        meeting.TaskName = developmentTasks[random.Next(developmentTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Tester"))
                    {
                        meeting.TaskName = testingTasks[random.Next(testingTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Support Engineer"))
                    {
                        meeting.TaskName = supportTasks[random.Next(supportTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Content writer"))
                    {
                        meeting.TaskName = documentationTasks[random.Next(documentationTasks.Count)];
                    }

                    this.Tasks?.Add(meeting);
                }
            }

            /// Plan daily scrum meeting  
            Task recurringMeeting = new Task();
            recurringMeeting.TaskName = "Scrum meeting";
            recurringMeeting.From = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 10, 0, 0);
            recurringMeeting.To = recurringMeeting.From.AddMinutes(30);
            recurringMeeting.Background = this.resourceColors[random.Next(resourceColors.Count)];
            recurringMeeting.Resources = new ObservableCollection<object>() { 2, 3, 4, 5, 6, 7, 8, 9 };
            recurringMeeting.IsAllDay = false;
            recurringMeeting.RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1";
            this.Tasks.Add(recurringMeeting);

            /// Plan weekly development meeting  
            Task overAllDevelopmentMeeting = new Task();
            overAllDevelopmentMeeting.TaskName = "Development meeting";
            overAllDevelopmentMeeting.From = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 11, 30, 0);
            overAllDevelopmentMeeting.To = overAllDevelopmentMeeting.From.AddMinutes(30);
            overAllDevelopmentMeeting.Background = this.resourceColors[random.Next(resourceColors.Count)];
            overAllDevelopmentMeeting.Resources = new ObservableCollection<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            overAllDevelopmentMeeting.IsAllDay = false;
            overAllDevelopmentMeeting.RecurrenceRule = "FREQ=WEEKLY;BYDAY=TU;INTERVAL=1";
            this.Tasks.Add(overAllDevelopmentMeeting);

        }

        /// <summary>
        /// Method to add colors for task and scheduler resources.
        /// </summary>
        private void AddResourcesColors()
        {
            this.resourceColors = new List<Brush>
            {
                Color.FromArgb("#FF8B1FA9"), Color.FromArgb("#FFD20100"), Color.FromArgb("#FFFC571D"), Color.FromArgb("#FF36B37B"), Color.FromArgb("#FF3D4FB5"),
                Color.FromArgb("#FF3D4FB5"), Color.FromArgb("#FF636363"),  Color.FromArgb("#FF636363"),  Color.FromArgb("#FF01A1EF"), Color.FromArgb("#FF0F8644"), Color.FromArgb("#FF00ABA9")
            };
        }

    }
}
