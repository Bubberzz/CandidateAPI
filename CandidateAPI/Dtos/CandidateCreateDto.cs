﻿using System.ComponentModel.DataAnnotations;

namespace CandidateAPI.Dtos
{
    public class CandidateCreateDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string[] Skills { get; set; }
    }
}
