using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPI.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
