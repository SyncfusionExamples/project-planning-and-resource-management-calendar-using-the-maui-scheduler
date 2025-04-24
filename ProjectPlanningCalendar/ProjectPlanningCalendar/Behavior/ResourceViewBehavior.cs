using Syncfusion.Maui.Scheduler;

namespace ProjectPlanningCalendar
{
    internal class ResourceViewBehavior : Behavior<SfScheduler>
    {
        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="scheduler">bindable value.</param>
        protected override void OnAttachedTo(SfScheduler scheduler)
        {
            base.OnAttachedTo(scheduler);
            scheduler.SelectableDayPredicate = (date) =>
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return false;
                }

                return true;
            };
        }
    }
}
