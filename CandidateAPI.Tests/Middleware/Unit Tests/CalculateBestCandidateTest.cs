using System.Collections.Generic;
using CandidateAPI.Middleware;
using CandidateAPI.Models;
using FluentAssertions;
using Xunit;

namespace CandidateAPI.Tests.Middleware.Unit_Tests
{
    public class CalculateBestCandidateTest
    {

        [Theory]
        [InlineData("java", "sql", "csharp", "python")]
        public void CalculateBestSkillMatchShouldReturnList(params string[] inputStrings)
        {
            // Arrange 
            var getBestMatch = new CalculateBestCandidate();
            var mockCandidates = new List<Candidate>
            {
                new Candidate()
                {
                    Id = "userid8723",
                    Name = "John Wick",
                    Skills = new[] {"java", "sql", "html"}
                },
                new Candidate()
                {
                    Id = "userid8724",
                    Name = "Dr Phil",
                    Skills = new[] {"java", "sql", "html", "csharp"}
                },
                new Candidate()
                {
                    Id = "userid8725",
                    Name = "Will Smith",
                    Skills = new[] {"java", "sql", "csharp", "python", "internet explorer"}
                },
            };

            var expectedResult = new List<Candidate>
            {
                new Candidate()
                {
                    Id = "userid8725",
                    Name = "Will Smith",
                    Skills = new[] {"java", "sql", "csharp", "python", "internet explorer"},
                    SkillMatch = 4
                }
            };

            // Act 
            var result = getBestMatch.ReturnResult(inputStrings, mockCandidates);

            // Assert
            expectedResult.Should().BeEquivalentTo(result);
        }

        [Theory]
        [InlineData("csharp", "python")]
        public void CalculateBestSkillMatchShouldReturnNothing(params string[] inputStrings)
        {
            // Arrange 
            var getBestMatch = new CalculateBestCandidate();
            var mockCandidates = new List<Candidate>
            {
                new Candidate()
                {
                    Id = "userid8723",
                    Name = "John Wick",
                    Skills = new[] {"java"}
                },
                new Candidate()
                {
                    Id = "userid8724",
                    Name = "Dr Phil",
                    Skills = new[] {"sql", "html", "photoshop"}
                },
                new Candidate()
                {
                    Id = "userid8725",
                    Name = "Will Smith",
                    Skills = new[] {"java", "sql", "internet explorer"}
                },
            };

            var expectedResult = new List<Candidate>();

            // Act 
            var result = getBestMatch.ReturnResult(inputStrings, mockCandidates);

            // Assert
            expectedResult.Should().BeEquivalentTo(result);
        }
    }
}
