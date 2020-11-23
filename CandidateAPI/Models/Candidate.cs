using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateAPI.Models
{
    public class Candidate
    {
        public string Id { get; set; }

        public string Name { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "please add at least one skill"), MinLength(1)]
        public string[] Skills { get; set; }

        public int SkillMatch { get; set; }
    }
}