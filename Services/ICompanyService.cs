using Data;
using System.Collections.Generic;

namespace Services
{
    public interface ICompanyService
    {
        string Create(Company c);
        List<Company> GetAll();
        Company? GetById(int id);
    }
}