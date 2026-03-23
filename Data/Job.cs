using System;

namespace Data;

public class Job
{
    public int JobId { get; set; }
    public string JobTitle { get; set; } = "";
    public string Company { get; set; } = "";
    public DateTime PostedDate { get; set; }
    public decimal Salary { get; set; }
    public decimal Hourly { get; set; }
}