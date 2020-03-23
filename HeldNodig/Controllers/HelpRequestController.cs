using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeldNodig.Dtos;
using HeldNodig.Entities;
using HeldNodig.Entities.HelpRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeldNodig.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelpRequestController : ControllerBase
    {
        private readonly IHelpRequestRepository _repository;
        private readonly IMapper _mapper;

        public HelpRequestController(IHelpRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<HelpRequest> Get()
        {
            return _repository.Query;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<HelpRequest> Store([FromBody]HelpRequestDto helpRequestDto)
        {
            var helpRequest = _mapper.Map<HelpRequest>(helpRequestDto);
            _repository.Add(helpRequest);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return helpRequest;
        }
        
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<HelpRequest> Update(Guid id, [FromBody]HelpRequestDto helpRequestDto)
        {
            var helpRequest = _mapper.Map<HelpRequest>(helpRequestDto);
            helpRequest.Id = id;
            _repository.Update(helpRequest);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return helpRequest;
        }
    }
}