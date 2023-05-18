using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Cabinet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual ICollection<Schedulechanged> Schedulechangeds { get; set; } = new List<Schedulechanged>();

    public virtual ICollection<Schedulestandart> Schedulestandarts { get; set; } = new List<Schedulestandart>();

    public override string ToString()
    {
        return Name;
    }
}
