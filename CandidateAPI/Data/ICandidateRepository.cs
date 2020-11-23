﻿using System.Collections.Generic;
using CandidateAPI.Models;

namespace CandidateAPI.Data
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates(string[] skills);
        void AddCandidate(Candidate candidate);
    }
}
