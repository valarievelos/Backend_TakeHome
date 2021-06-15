using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RatingEngine.Data.Interfaces;
using RatingEngine.Data.Models;
using RatingEngine.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RatingEngineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private IRateRepository rates;
        private IRateRepository jsonInputs;

        public RatesController(IRateRepository _rates, IRateRepository _jsonInputs)
        {
            this.rates = _rates;
            this.jsonInputs = _jsonInputs;
        }

        [HttpPost]
        public ActionResult<JsonOutputs> GetInputs(JsonInputs request)
        {
            if(jsonInputs.AddInput(request))
            {
                return jsonInputs.GetPremium();
            }

            return BadRequest();   
        }

        [HttpGet]
        public ActionResult<List<JsonInputs>> GetInputs()
        {
            return jsonInputs.GetInputs();
        }
    }
}
