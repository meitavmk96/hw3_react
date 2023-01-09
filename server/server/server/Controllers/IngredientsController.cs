using Microsoft.AspNetCore.Mvc;
using server.Modals;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        //קריאה
        // GET: api/<IngredientsController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            Ingredient ingredient = new Ingredient();
            return ingredient.Read(); //הפעלת פו שנמצאת במחלקת מרכיב
        }

        //הכנסה
        // POST api/<IngredientsController>
        [HttpPost]
        public bool Post([FromBody] Ingredient ingredient)
        {
            bool numEffected = ingredient.Insert(); //הפעלת פו שנמצאת במחלקת מרכיב
            return numEffected;
        }

    }
}
