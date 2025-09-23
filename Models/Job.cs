using System;

public class Job
{
    public int JobId { get; set; }
    public string Code { get; set; } // JOB-01 etc
    public string Title { get; set; }
    public string Description { get; set; }
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime ClosingDate { get; set; }

    public virtual Location Location { get; set; }
    public virtual Department Department { get; set; }
}

public class Department
{
}