using CandidateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateAPI.Middleware;

namespace CandidateAPI.Data
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public CandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public void PostCandidate(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }
            _context.Candidates.Add(candidate);
        }

        public IEnumerable<Candidate> GetCandidates(string[] skills)
        {
            var bestMatch = new CalculateBestCandidate();
            return bestMatch.ReturnResult(skills, _context.Candidates.ToList());
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
