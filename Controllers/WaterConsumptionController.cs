using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterWatch.Repository;
using WaterWatch.Models;

namespace WaterWatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterConsumptionController : ControllerBase
    {
        private readonly IWaterConsumptionRepository _waterConsumptionRepository;

        public WaterConsumptionController(IWaterConsumptionRepository waterConsumptionRepository)
        {
            _waterConsumptionRepository = waterConsumptionRepository;
        }

        [HttpGet("/waterconsumption/getall")]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> GetAll()
        {
            var wcData = await _waterConsumptionRepository.GetAll();
            return Ok(wcData);
        }

        [HttpGet("/waterconsumption/topten")]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> GetTopTen()
        {
            var wcData = await _waterConsumptionRepository.GetTopConsumers();
            return Ok(wcData);
        }
    }
}