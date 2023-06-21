using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SolarCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolarCalculatorController : ControllerBase
    {
        private Dictionary<string, double> cityAverages = new Dictionary<string, double>
        {
            { "Sorocaba", 4.948 },
            { "São Paulo", 4.629 },
            { "Campinas", 5.105 },
            { "Guarulhos", 4.636 },
            { "São Bernardo do Campo", 4.508 }
        };

        private Dictionary<string, int> energyTypes = new Dictionary<string, int>
        {
            { "Monofásico", 30 },
            { "Bifásico", 50 },
            { "Trifásico", 100 }
        };

        private class Module
        {
            public string Model { get; set; }
            public double Pmax { get; set; }
            public double Vmp { get; set; }
            public double Imp { get; set; }
            public double Voc { get; set; }
            public double Isc { get; set; }
            public double Efi { get; set; }
            public double If_max { get; set; }
            public double Coef_Pmax { get; set; }
            public double Coef_Voc { get; set; }
            public double Coef_Isc { get; set; }
        }

        private class Inverter
        {
            public string Model { get; set; }
            public int In_Pmax { get; set; }
            public int In_Vmin { get; set; }
            public int In_Vmax { get; set; }
            public int Mppt { get; set; }
            public int Pmax_Mppt { get; set; }
            public int Vmin_Mppt { get; set; }
            public int Vmax_Mppt { get; set; }
            public double In_Imax { get; set; }
            public double In_Isc { get; set; }
            public int Out_Pnom { get; set; }
            public int Out_Pmax { get; set; }
            public int Out_Vnom { get; set; }
            public int Out_Vmax { get; set; }
            public double Out_Imax { get; set; }
        }

        [HttpGet("generation/{city}/{energyType}")]
        public IActionResult CalculateGeneration(string city, string energyType, [FromQuery] List<double> monthlyConsumptions)
        {
            if (!cityAverages.ContainsKey(city) || !energyTypes.ContainsKey(energyType))
            {
                return BadRequest("Invalid city or energy type.");
            }

            double average = cityAverages[city];
            int type = energyTypes[energyType];

            List<double> generation = monthlyConsumptions.Select(consumption => average * consumption).ToList();

            return Ok(generation);
        }

        [HttpGet("system/{moduleModel}/{inverterModel}")]
        public IActionResult CalculateSystem(string moduleModel, string inverterModel)
        {
            Module module = GetModule(moduleModel);
            Inverter inverter = GetInverter(inverterModel);

            double pdcMax = inverter.In_Pmax;
            double potenciaPainel = module.Pmax * (1 + ((module.Coef_Pmax * 37) / 100));

            int numModulos = (int)(pdcMax / potenciaPainel);

            bool isValid = ValidateCombination(module, inverter, numModulos);

            if (!isValid)
            {
                return BadRequest("Invalid combination of module and inverter.");
            }

            double potenciaTotal = potenciaPainel * numModulos;

            var result = new
            {
                ModuleModel = module.Model,
                NumModules = numModulos,
                InverterModel = inverter.Model,
                NumInverters = 1,
                TotalPower = potenciaTotal
            };

            return Ok(result);
        }

        private Module GetModule(string moduleModel)
        {
            // Here you would fetch the module data from a database or other source
            // For simplicity, we'll hard-code the module data here

            var modules = new List<Module>
            {
                new Module
                {
                    Model = "CS3W HIKU6 144 CELLS HALF-CELL MONO 430",
                    Pmax = 430,
                    Vmp = 40.3,
                    Imp = 10.68,
                    Voc = 48.3,
                    Isc = 11.37,
                    Efi = 19.5,
                    If_max = 20,
                    Coef_Pmax = -0.35,
                    Coef_Voc = -0.27,
                    Coef_Isc = 0.05
                },
                // Add other module data here
            };

            return modules.FirstOrDefault(m => m.Model == moduleModel);
        }

        private Inverter GetInverter(string inverterModel)
        {
            // Here you would fetch the inverter data from a database or other source
            // For simplicity, we'll hard-code the inverter data here

            var inverters = new List<Inverter>
            {
                new Inverter
                {
                    Model = "CSI-4KTL1P-GI-FL",
                    In_Pmax = 4600,
                    In_Vmin = 120,
                    In_Vmax = 600,
                    Mppt = 2,
                    Pmax_Mppt = 4000,
                    Vmin_Mppt = 90,
                    Vmax_Mppt = 520,
                    In_Imax = 11,
                    In_Isc = 17.2,
                    Out_Pnom = 4000,
                    Out_Pmax = 4400,
                    Out_Vnom = 220,
                    Out_Vmax = 240,
                    Out_Imax = 21
                },
                // Add other inverter data here
            };

            return inverters.FirstOrDefault(i => i.Model == inverterModel);
        }

        private bool ValidateCombination(Module module, Inverter inverter, int numModulos)
        {
            // Perform validation checks here and return true or false based on the result
            // You can use the module and inverter data to perform the necessary checks

            // Placeholder validation (always returns true)
            return true;
        }
    }
}
