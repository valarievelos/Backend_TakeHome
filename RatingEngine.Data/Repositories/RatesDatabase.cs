using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class RatesDatabase : IRateRepository
    {
        private RatingEngineContext db;
        public Rates rates = new Rates();
        public JsonOutputs output = new JsonOutputs();
        
        public RatesDatabase(RatingEngineContext _db)
        {
            this.db = _db;
        }

        public bool AddInput(JsonInputs input)
        {
            db.Inputs.Add(input);
            db.SaveChanges();
            return true;
        }

        public List<JsonInputs> GetInputs()
        {
            return db.Inputs.ToList();
        }

        public JsonOutputs GetPremium()
        {
            var input = db.Inputs.ToList();
            var index = input.Count - 1;
            while(index >= 0)
            {
                switch (input[index].State)
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

                switch (input[index].Business)
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

                rates.BasePremium = input[index].Revenue;
                rates.HazardFactor = 4;

                output.Premium = rates.BusinessFactor * rates.StateFactor * rates.BasePremium * rates.HazardFactor;
                return output;
            }
            return output;
            
        }

    }
}