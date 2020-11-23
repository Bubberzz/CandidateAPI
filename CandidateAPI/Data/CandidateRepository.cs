using CandidateAPI.Models;
using System;
using System.Collections.Generic;

namespace CandidateAPI.Data
{
    public class CandidateRepository : ICandidateRepository
    {
        public void PostCandidate(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }
        }

        public IEnumerable<Candidate> GetCandidates(string[] skills)
        {
            var candidates = new List<Candidate>();
            return candidates;
        }
    }
}
