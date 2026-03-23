using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class CompanyService : ICompanyService
{
    private static List<Company> _companies = new List<Company>()
    {
        new Company { CompanyId=1, CompanyName="TechNova", ContactName="Karen Smith", Phone="555-888-1111", Email="karen@technova.com", Website="https://technova.com" },
        new Company { CompanyId=2, CompanyName="CloudPeak", ContactName="Daniel Roberts", Phone="555-888-2222", Email="daniel@cloudpeak.com", Website="https://cloudpeak.io" },
        new Company { CompanyId=3, CompanyName="Skyline Systems", ContactName="Angela Kim", Phone="555-888-3333", Email="angela@skyline.com", Website="https://skylinesystems.com" },
        new Company { CompanyId=4, CompanyName="BlueWave Labs", ContactName="Robert King", Phone="555-888-4444", Email="robert@bluewave.com", Website="https://bluewavelabs.com" }
    };

    public List<Company> GetAll()
    {
        return _companies;
    }

    public Company? GetById(int id)
    {
        return _companies.FirstOrDefault(c => c.CompanyId == id);
    }

    public string Create(Company c)
    {
        _companies.Add(c);
        return $"Candidate {c.CompanyName} added. We now have {_companies.Count} companies";
    }
}
