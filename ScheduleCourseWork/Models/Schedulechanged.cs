using System;
using System.Collections.Generic;

namespace ScheduleCourseWork.Models;

public partial class Schedulechanged
{
    public int Id { get; set; }

    public int Cabinet { get; set; }

    public int Teacher { get; set; }

    public int Schedulecurrent { get; set; }

    public int Studygroup { get; set; }

    public int Sequencenumber { get; set; }

    public int Subject { get; set; }

    public string Division { get; set; } = null!;

    public bool isremote { get; set; }

    public virtual Cabinet CabinetNavigation { get; set; } = null!;

    public virtual Schedulecurrent SchedulecurrentNavigation { get; set; } = null!;

    public virtual Teacher TeacherNavigation { get; set; } = null!;

    public virtual Studygroup StudygroupNavigation { get; set; } = null!;

    public virtual Subject SubjectNavigation { get; set; } = null!;
}
