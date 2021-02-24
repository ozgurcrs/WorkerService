using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Data;
using Worker.Model;

namespace Worker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly FoodData _data;

        public FoodController(FoodData data)
        {
            _data = data;
        }

        [HttpGet]
        public List<Food> Get()
        {
            return _data._foodData;
        }

        [HttpPost]
        public Food Post([FromBody] Food food)
        {
             _data._foodData.Add(food);
            return food;
        }
    }
}
