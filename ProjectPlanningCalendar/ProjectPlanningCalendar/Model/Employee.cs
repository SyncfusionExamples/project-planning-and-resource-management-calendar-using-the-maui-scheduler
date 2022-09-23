namespace ProjectPlanningCalendar
{
    public class Employee
    {
        public Employee()
        {
            this.Id = this.GetHashCode();
        }

        public string Name { get; set; }

        public object Id { get; set; }

        public Brush Background { get; set; }

        public string ImageName { get; set; }

        public string Role { get; set; } 
    }
}
