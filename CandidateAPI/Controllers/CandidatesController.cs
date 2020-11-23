using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CandidateAPI.Data;
using CandidateAPI.Dtos;
using CandidateAPI.Models;

namespace CandidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("search")]
        [HttpGet]
        public ActionResult<Candidate> GetCandidate([FromQuery] string skills)
        {
            if (skills == null)
            {
                return NotFound("Please enter skills in the following format: \n" +
                                "/candidates/search?skills=javascript,express,mongodb ");
            }
            var value = skills.Split(',');
            var candidates = _repository.GetCandidates(value);

            if (candidates?.Any() == true)
            {
                return Ok(_mapper.Map<IEnumerable<CandidateReadDto>>(candidates));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(CandidateCreateDto candidateCreateDto)
        {
            var candidateModel = _mapper.Map<Candidate>(candidateCreateDto);
            _repository.PostCandidate(candidateModel);
            try
            {
                await _repository.SaveChanges().ConfigureAwait(false);
            }
            catch (ArgumentException)
            {
                return Conflict("ID already exists");
            }
            return Ok();
        }
    }
}
