using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterWatch.Models;
using WaterWatch.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            SaveData();
            return await _context.Consumptions.ToListAsync();
        }

        public async Task<IEnumerable<WaterConsumption>> GetTopConsumers()
        {
            return await _context.Consumptions.OrderByDescending(c => c.averageMontlyKL).Take(10).ToListAsync();
        }

        public void SaveData()
        {
            var res_dataset = _context.Consumptions.ToList();

            if (res_dataset.Count == 0)
            {
                Console.WriteLine("No data found in database. Adding data from JSON file.");

                var geojson = File.ReadAllText("/home/fernando/Downloads/water_consumption.geojson");
                dynamic jsonObj = JsonConvert.DeserializeObject(geojson);

                foreach (var feature in jsonObj["features"])
                {
                    string str_neighbourhood = feature["properties"]["neighbourhood"];
                    string str_suburb_group = feature["properties"]["suburb_group"];
                    string str_avgMonthlyKL = feature["properties"]["averageMonthlyKL"];
                    string str_geometry = feature["geometry"]["coordinates"].ToString(Newtonsoft.Json.Formatting.None);

                    string conv_averageMontlyKL = str_avgMonthlyKL.Replace(".0", "");
                    int avgMontlyKL = Convert.ToInt32(conv_averageMontlyKL);


                    WaterConsumption consumption = new WaterConsumption()
                    {
                        neighbourhood = str_neighbourhood,
                        suburb_group = str_suburb_group,
                        averageMontlyKL = avgMontlyKL,
                        coordinates = str_geometry
                    };

                    _context.Consumptions.Add(consumption);
                    _context.SaveChanges();
                };
            }
            else
            {
                Console.WriteLine("Data already exists in database.");
            }
        }
    }
}