using RatingEngine.Data.Models;
using System;
using System.Collections.Generic;

namespace RatingEngine.Data.Interfaces
{
    public interface IRateRepository
    {

        public bool AddInput(JsonInputs input);

        public JsonOutputs GetPremium();

        public List<JsonInputs> GetInputs();

    }
}
