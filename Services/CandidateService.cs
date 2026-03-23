using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class CandidateService : ICandidateService
{

    private static List<Candidate> _candidates = new()
{
    new Candidate
    {
        Id = 1,
        Name = "Sarah Johnson",
        Email = "sarah.johnson@example.com",
        Phone = "555-123-4567",
        City = "Los Angeles",
        State = "CA",
        Zip = "90001",
        Profession = "Software Engineer"
    },
    new Candidate
    {
        Id = 2,
        Name = "Michael Chen",
        Email = "michael.chen@example.com",
        Phone = "555-987-6543",
        City = "Seattle",
        State = "WA",
        Zip = "98101",
        Profession = "DevOps Engineer"
    },
    new Candidate
    {
        Id = 3,
        Name = "Emily Rodriguez",
        Email = "emily.rodriguez@example.com",
        Phone = "555-222-7788",
        City = "Austin",
        State = "TX",
        Zip = "73301",
        Profession = "UX Designer"
    }
};

    public List<Candidate> GetAll()
    {
        return _candidates;
    }

    public Candidate? GetById(int id)
    {
        return _candidates.FirstOrDefault(c => c.Id == id);
    }

    public string Create(Candidate candidate)
    {
        _candidates.Add(candidate);
        return $"Candidate {candidate.Name} added. We now have {_candidates.Count} candidates";
    }

}
