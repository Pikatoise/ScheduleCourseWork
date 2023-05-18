using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Schedulecurrent
{
    public int Id { get; set; }

    public DateOnly Currentdate { get; set; }

    public int Weekday { get; set; }

    public string Daytype { get; set; } = null!;

    public virtual ICollection<Schedulechanged> Schedulechangeds { get; set; } = new List<Schedulechanged>();

    public virtual Weekday WeekdayNavigation { get; set; } = null!;
}
