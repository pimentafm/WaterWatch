using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterWatch.Models
{
    public class WaterConsumption
    {
        public int Id { get; set; }
        public required string neighbourhood { get; set; }
        public required string suburb_group { get; set; }
        public int averageMonthlyKL { get; set; }
        public required string coordinates { get; set; }
    }
}