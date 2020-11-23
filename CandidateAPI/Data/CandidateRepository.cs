using CandidateAPI.Models;
using System;
using System.Collections.Generic;

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
            var candidates = new List<Candidate>();
            return candidates;
        }
    }
}
