using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Schedulestandart> Schedulestandarts { get; set; } = new List<Schedulestandart>();

    public virtual ICollection<Schedulechanged> Schedulechangeds { get; set; } = new List<Schedulechanged>();

    public override string ToString()
    {
        return Name;
    }
}
