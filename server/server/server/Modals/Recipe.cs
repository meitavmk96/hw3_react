
namespace server.Modals
{
    public class Recipe
    {
        int id;
        string name;
        string image;
        string cookingMethod;
        int time;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string CookingMethod { get => cookingMethod; set => cookingMethod = value; }
        public int Time { get => time; set => time = value; }

        public Recipe(int id, string name, string image,string cookingMethod, int time)
        {
            Id = id;
            Name = name;
            Image = image;
            CookingMethod = cookingMethod;
            Time = time;
        }

        public Recipe() { }

        public List<Recipe> Read()//קריאה
        {
            DBservices dbs = new DBservices();
            return dbs.ReadRecipe();//"הפעלת פו שנמצאת שמחלקה "שירותי דטהביס
        }

        public List<Ingredient> ReadIngredientForRecipe(int recipeId)//קריאה
        {
            DBservices dbs = new DBservices();
            return dbs.ReadIngredientForRecipe(recipeId);//DBקריאה ל
        }

        public int Insert()
        {//הכנסה
            DBservices dbs = new DBservices();
            return dbs.InsertRecipe(this);//"הפעלת פו שנמצאת שמחלקה "שירותי דטהביס
        }

        public bool InsertIngredientForRecipe(int recipeId, int ingredientId) //הכנסה
        {
            DBservices dbs = new DBservices();
            dbs.InsertIngredientForRecipe(recipeId, ingredientId);//"הפעלת פו שנמצאת שמחלקה "שירותי דטהביס
            return true;
        }

    }
}
