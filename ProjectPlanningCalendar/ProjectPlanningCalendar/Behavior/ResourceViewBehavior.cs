using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanningCalendar
{
    internal class ResourceViewBehavior : Behavior<SfScheduler>
    {
        /// <summary>
        /// the scheduler object.
        /// </summary>
        private SfScheduler? scheduler;

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value.</param>
        protected override void OnAttachedTo(SfScheduler bindable)
        {
            base.OnAttachedTo(bindable);
            this.scheduler = bindable;
            this.scheduler.ViewChanged += this.OnSchedulerViewChanged;
        }

        /// <summary>
        /// Invokes on scheduler view type changed.
        /// </summary>
        /// <param name="sender">The scheduler object.</param>
        /// <param name="e">The scheduler view changed event args.</param>
        private void OnSchedulerViewChanged(object? sender, SchedulerViewChangedEventArgs e)
        {
            scheduler.SelectableDayPredicate = (date) =>
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return false;
                }

                return true;
            };
        }

        /// <summary>
        /// Begins when the behavior detaching from the view. 
        /// </summary>
        /// <param name="bindable">bindable value.</param>
        protected override void OnDetachingFrom(SfScheduler bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.scheduler != null)
            {
                this.scheduler.ViewChanged -= this.OnSchedulerViewChanged;
                this.scheduler = null;
            }
        }
    }
}
