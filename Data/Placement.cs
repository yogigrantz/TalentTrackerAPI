using System.Collections.Generic;

namespace Data;

public class Placement
{
    public int PlacementId { get; set; }
    public int JobId { get; set; }
    public int ClientId { get; set; }
    public string CompanyName { get; set; } = "";
    public string JobTitle { get; set; } = "";
    public List<string> CandidateNames { get; set; } = new();
}
