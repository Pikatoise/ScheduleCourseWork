using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Surname { get; set; }

    public string Fullname { 
        get 
        { 
            return $"{Lastname} {Firstname} {Surname}"; 
        }
    }

    public virtual ICollection<Schedulechanged> Schedulechangeds { get; set; } = new List<Schedulechanged>();

    public virtual ICollection<Schedulestandart> Schedulestandarts { get; set; } = new List<Schedulestandart>();

    public override string ToString()
    {
        return Fullname;
    }
}
