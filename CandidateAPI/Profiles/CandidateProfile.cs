using CandidateAPI.Dtos;
using CandidateAPI.Models;
using AutoMapper;

namespace CandidateAPI.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateReadDto>();
            CreateMap<CandidateCreateDto, Candidate>();
        }
    }
}
