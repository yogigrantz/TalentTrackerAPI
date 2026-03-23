using Data;
using System.Collections.Generic;

namespace Services
{
    public interface IJobService
    {
        string Create(Job j);
        List<Job> GetAll();
        Job? GetById(int id);
    }
}