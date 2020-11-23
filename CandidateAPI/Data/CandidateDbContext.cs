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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .Property(e => e.Skills)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
