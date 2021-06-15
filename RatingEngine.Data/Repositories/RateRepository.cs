using RatingEngine.Data.Interfaces;
using RatingEngine.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingEngine.Data.Repositories
{
    public class RateRepository : IRateRepository
    {

        public List<JsonInputs> inputs = new List<JsonInputs>()
        {
            new JsonInputs {}
        };

        public Rates rates = new Rates();
        public JsonOutputs output = new JsonOutputs();

        public RateRepository(List<JsonInputs> inputs)
        {
            this.inputs = inputs;
        }

        public bool AddInput(JsonInputs input)
        {
            return true;
        }

        public List<JsonInputs> GetInputs()
        {
            return inputs;
        }

        public JsonOutputs GetPremium()
        {
            switch(inputs[0].State)
            {
                case "TX": 
                    rates.StateFactor = 0.943;
                    break;
                case "FL": 
                    rates.StateFactor = 1.2;
                    break;
                case "OH":
                    rates.StateFactor = 1;
                    break;
                default:
                    rates.StateFactor = 0.00;
                    break;
            }

            switch (inputs[0].Business)
            {
                case "Architect":
                    rates.BusinessFactor = 1;
                    break;
                case "Plumber":
                    rates.BusinessFactor = 0.5;
                    break;
                case "Programmer":
                    rates.BusinessFactor = 1.25;
                    break;
                default:
                    rates.StateFactor = 0.00;
                    break;
            }

            rates.BasePremium = inputs[0].Revenue;
            rates.HazardFactor = 4;

            output.Premium = rates.BusinessFactor * rates.StateFactor * rates.BasePremium * rates.HazardFactor;

            return output;
        }

    }
}
