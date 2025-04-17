namespace ProjectPlanningCalendar
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets employee name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets resource object id.
        /// </summary>
        public object? Id { get; set; }

        /// <summary>
        /// Gets or sets employee background.
        /// </summary>
        public Brush? Background { get; set; }

        /// <summary>
        /// Gets or sets image for an employee.
        /// </summary>
        public string ImageName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets employee role.
        /// </summary>
        public string Role { get; set; } = string.Empty;
    }
}
