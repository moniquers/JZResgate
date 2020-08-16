using JZResgate.Domain.ApiModels;
using JZResgate.Infra.Data.ApiModels;
using JZResgate.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace JZResgate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecoveryTruckController : ControllerBase
    {
        private readonly IRecoveryTruckRepository _recoveryTruckRepository;

        public RecoveryTruckController(IRecoveryTruckRepository recoveryTruckRepository)
        {
            _recoveryTruckRepository = recoveryTruckRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _recoveryTruckRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _recoveryTruckRepository.GetById(id);
                return Ok(response);
            }
            catch (Exception exception)
            {
                var response = new DefaultResponse
                {
                    Success = false,
                    ErrorMessage = exception.Message
                };
                return NotFound(response);
            }
        }

        [HttpPost]
        public IActionResult Create(RecoveryTruckRequest recoveryTruckRequest)
        {
            var response = _recoveryTruckRepository.Create(recoveryTruckRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(RecoveryTruckRequest recoveryTruckRequest, Guid id)
        {
            var errorMessage = _recoveryTruckRepository.Update(recoveryTruckRequest, id);
            var response = new DefaultResponse
            {
                Success = string.IsNullOrWhiteSpace(errorMessage),
                ErrorMessage = errorMessage
            };

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var errorMessage = _recoveryTruckRepository.Delete(id);
            var response = new DefaultResponse
            {
                Success = string.IsNullOrWhiteSpace(errorMessage),
                ErrorMessage = errorMessage
            };

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

    }
}
