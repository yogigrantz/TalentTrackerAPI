using Data;
using System.Collections.Generic;

namespace Services
{
    public interface IPlacementService
    {
        string Create(Placement j);
        List<Placement> GetAll();
        Placement? GetById(int id);
    }
}