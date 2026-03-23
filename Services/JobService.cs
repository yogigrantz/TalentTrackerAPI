using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class JobService : IJobService
{
    private static List<Job> _jobs = new List<Job>()
    {
            new Job { JobId=1, JobTitle="Senior .NET Developer", Company="TechNova", PostedDate=DateTime.Today.AddDays(-5), Salary=145000, Hourly=0 },
            new Job { JobId=2, JobTitle="Angular Developer", Company="CloudPeak", PostedDate=DateTime.Today.AddDays(-3), Salary=130000, Hourly=0 },
            new Job { JobId=3, JobTitle="DevOps Engineer", Company="Skyline Systems", PostedDate=DateTime.Today.AddDays(-10), Salary=150000, Hourly=0 },
            new Job { JobId=4, JobTitle="QA Automation Engineer", Company="BlueWave Labs", PostedDate=DateTime.Today.AddDays(-7), Salary=110000, Hourly=0 },
            new Job { JobId=5, JobTitle="Contract Backend Developer", Company="TechNova", PostedDate=DateTime.Today.AddDays(-1), Salary=0, Hourly=85 }
    };

    public List<Job> GetAll()
    {
        return _jobs;
    }

    public Job? GetById(int id)
    {
        return _jobs.FirstOrDefault(c => c.JobId == id);
    }

    public string Create(Job j)
    {
        _jobs.Add(j);
        return $"Candidate {j.JobTitle} added. We now have {_jobs.Count} jobs";
    }

}
