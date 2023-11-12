using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterWatch.Models;
using WaterWatch.Data;
using Microsoft.EntityFrameworkCore;

namespace WaterWatch.Repository
{
    public class WaterConsumptionRepository : IWaterConsumptionRepository
    {
        private readonly IDataContext _context;

        public WaterConsumptionRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WaterConsumption>> GetAll()
        {
            return await _context.Consumptions.ToListAsync();
        }

        public async Task<IEnumerable<WaterConsumption>> GetTopConsumers()
        {
            return await _context.Consumptions.OrderByDescending(c => c.averageMontlyKL).Take(10).ToListAsync();
        }
    }
}