using System.Collections.Generic;
using System.Threading.Tasks;
using CandidateAPI.Models;

namespace CandidateAPI.Data
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates(string[] skills);
        void PostCandidate(Candidate candidate);
        Task<int> SaveChanges();
    }
}
