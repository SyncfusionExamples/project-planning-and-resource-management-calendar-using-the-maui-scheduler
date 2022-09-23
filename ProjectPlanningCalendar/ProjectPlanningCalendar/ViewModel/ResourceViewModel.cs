using System.Collections.ObjectModel;

namespace ProjectPlanningCalendar
{
    public class ResourceViewModel
    {
        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public List<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets resources to the scheduler.
        /// </summary>
        public List<object> Resources { get; set; }

        /// <summary>
        /// colors for employee task and scheduler resources
        /// </summary>
        private List<Brush> resourceColors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceViewModel" /> class.
        /// </summary>
        public ResourceViewModel()
        {
            this.resourceColors = this.GetResourceColors();
            this.Resources = this.GetSchedulerResources();
            this.Tasks = this.GetEmployeeTasks();
        }

        /// <summary>
        /// Method to add resources or employees to the scheduler.
        /// </summary>
        /// <returns>Scheduler resources</returns>
        private List<object> GetSchedulerResources()
        {
            Random random = new();
            List<object> resources = new();
            List<string> employeeNames = new List<string>
            {
                  "Robert", "Sophia", "Emilia" , "Stephen",  "James William", "Johnny", "Daniel", "Adeline Ruby","Kinsley Elena",
            };

            for (int i = 0; i < 9; i++)
            {
                Employee employees = new();
                employees.Name = employeeNames[i];
                employees.Background = this.resourceColors[random.Next(this.resourceColors.Count)];
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
                resources.Add(employees);
            }

            return resources;
        }

        /// <summary>
        /// Method to create tasks.
        /// </summary>
        /// <returns>Employee tasks</returns>
        private List<Task> GetEmployeeTasks()
        {
            Random random = new();
            List<Task> tasks = new();
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
                    Task task = new();
                    task.From = startDate;
                    task.To = startDate.AddDays(4).AddHours(1);
                    task.Background = this.resourceColors[random.Next(resourceColors.Count)];
                    task.Resources = new ObservableCollection<object>() { resource.Id };
                    task.IsAllDay = true;

                    if (string.Equals(resource.Role, "Project manager"))
                    {
                        task.TaskName = managerTasks[random.Next(managerTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Team lead"))
                    {
                        task.TaskName = teamleadTasks[random.Next(teamleadTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Developer"))
                    {
                        task.TaskName = developmentTasks[random.Next(developmentTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Tester"))
                    {
                        task.TaskName = testingTasks[random.Next(testingTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Support Engineer"))
                    {
                        task.TaskName = supportTasks[random.Next(supportTasks.Count)];
                    }
                    else if (string.Equals(resource.Role, "Content writer"))
                    {
                        task.TaskName = documentationTasks[random.Next(documentationTasks.Count)];
                    }

                    tasks.Add(task);
                }
            }

            //// Plan daily scrum meeting  
            Task recurringMeeting = new();
            recurringMeeting.TaskName = "Scrum meeting";
            recurringMeeting.From = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 10, 0, 0);
            recurringMeeting.To = recurringMeeting.From.AddMinutes(30);
            recurringMeeting.Background = Color.FromArgb("#FF3D4FB5");
            recurringMeeting.Resources = new ObservableCollection<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            recurringMeeting.IsAllDay = false;
            recurringMeeting.RecurrenceRule = "FREQ=WEEKLY;BYDAY=TU,WE,TH;INTERVAL=1";
            tasks.Add(recurringMeeting);

            //// Plan weekly development meeting  
            Task overAllDevelopmentMeeting = new();
            overAllDevelopmentMeeting.TaskName = "Development meeting";
            overAllDevelopmentMeeting.From = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 11, 30, 0);
            overAllDevelopmentMeeting.To = overAllDevelopmentMeeting.From.AddMinutes(30);
            overAllDevelopmentMeeting.Background = Color.FromArgb("#FF36B37B");
            overAllDevelopmentMeeting.Resources = new ObservableCollection<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            overAllDevelopmentMeeting.IsAllDay = false;
            overAllDevelopmentMeeting.RecurrenceRule = "FREQ=WEEKLY;BYDAY=TU;INTERVAL=1";
            tasks.Add(overAllDevelopmentMeeting);

            return tasks;
        }

        /// <summary>
        /// Method to add colors for employee task and scheduler resources.
        /// </summary>
        /// <returns>resource colors</returns>
        private List<Brush> GetResourceColors()
        {
            return new List<Brush>
            {
                Color.FromArgb("#FF8B1FA9"), Color.FromArgb("#FFD20100"), Color.FromArgb("#FFFC571D"), Color.FromArgb("#FF36B37B"), Color.FromArgb("#FF3D4FB5"),
                Color.FromArgb("#FF3D4FB5"), Color.FromArgb("#FF01A1EF"), Color.FromArgb("#FF0F8644"), Color.FromArgb("#FF00ABA9")
            };
        }

    }
}
