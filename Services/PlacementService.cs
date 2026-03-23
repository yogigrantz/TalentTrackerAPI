using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class PlacementService : IPlacementService
{
    private static List<Placement> _placements = new List<Placement>()
    {
        new Placement
        {
            PlacementId = 1,
            JobId = 1,
            ClientId = 1,
            CompanyName = "TechNova",
            JobTitle = "Senior .NET Developer",
            CandidateNames = new List<string> { "Sarah Johnson", "David Patel" }
        },

        new Placement
        {
            PlacementId = 2,
            JobId = 2,
            ClientId = 2,
            CompanyName = "CloudPeak",
            JobTitle = "Angular Developer",
            CandidateNames = new List<string> { "Emily Rodriguez" }
        },
        new Placement
        {
            PlacementId = 3,
            JobId = 3,
            ClientId = 3,
            CompanyName = "Skyline Systems",
            JobTitle = "DevOps Engineer",
            CandidateNames = new List<string> { "Michael Chen" }
        }
    };

    public List<Placement> GetAll()
    {
        return _placements;
    }

    public Placement? GetById(int id)
    {
        return _placements.FirstOrDefault(c => c.PlacementId == id);
    }

    public string Create(Placement j)
    {
        _placements.Add(j);
        return $"Candidate {j.JobTitle} added. We now have {_placements.Count} placements";
    }
}
