using Microsoft.AspNetCore.Mvc;
using server.Modals;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        //קריאה
        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            Recipe recipe = new Recipe();
            return recipe.Read(); //הפעלת פו שנמצאת במחלקת מתכון
        }

        //קריאה
        // GET: api/<RecipesController>
        [HttpGet("GetIngredientForRecipe/{id}")]
        public IEnumerable<Ingredient> GetIngredientForRecipe(int id)
        {
            Recipe recipe = new Recipe();
            return recipe.ReadIngredientForRecipe(id); //הפעלת פו שנמצאת במחלקת מתכון
        }


        //הכנסה
        // POST api/<RecipesController>
        [HttpPost]
        public int Post([FromBody] Recipe recipe)
        {
            return recipe.Insert(); //הפעלת פו שנמצאת במחלקת מתכון
        }


        // POST api/<RecipesController>
        [HttpPost("PostIngredientForRecipe/{id}")]
        public bool PostIngredientForRecipe(int id, int ingredientId)
        {
            Recipe recipe = new Recipe();
            return recipe.InsertIngredientForRecipe(id, ingredientId); //הפעלת פו שנמצאת במחלקת הספרים
        }
    }
}
