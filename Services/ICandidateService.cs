
using Data;
using System.Collections.Generic;

namespace Services;

public interface ICandidateService
{
    List<Candidate> GetAll();
    Candidate? GetById(int id);
    string Create(Candidate candidate);
}