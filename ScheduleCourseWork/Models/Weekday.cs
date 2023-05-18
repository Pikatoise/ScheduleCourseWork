using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Weekday
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Schedulecurrent> Schedulecurrents { get; set; } = new List<Schedulecurrent>();

    public virtual ICollection<Schedulestandart> Schedulestandarts { get; set; } = new List<Schedulestandart>();

    public override string ToString()
    {
        return Name;
    }
}
