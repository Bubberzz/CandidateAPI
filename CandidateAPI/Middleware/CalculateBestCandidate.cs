using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateAPI.Models;

namespace CandidateAPI.Middleware
{
    public class CalculateBestCandidate
    {
        public List<Candidate> ReturnResult(string[] skills, List<Candidate> candidates)
        {
            var result = new List<Candidate>();

            foreach (var candidate in candidates)
            {
                var skillsMatch = (
                    from skillInput
                        in skills
                    let skillsArray = candidate.Skills
                    where skillsArray.Any(skill => skillInput == skill)
                    select skillInput).Count();
                if (skillsMatch == 0) continue;
                candidate.SkillMatch = skillsMatch;
                result.Add(candidate);
            }

            if (result.Count == 0)
            {
                return result;
            }

            var bestMatch = result.OrderByDescending(x => x.SkillMatch).First();
            result.Clear();
            result.Add(bestMatch);
            return result;
        }
    }
}
