using Microsoft.AspNetCore.Mvc.RazorPages;

namespace server.Modals
{
    public class Ingredient
    {

        int id;
        string name;
        string image;
        int calories;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Calories { get => calories; set => calories = value; }

        public Ingredient(int id, string name, string image,int calories)
        {
            Id = id;
            Name = name;
            Image = image;
            Calories = calories;
        }

        public Ingredient() { }

        public List<Ingredient> Read()//קריאה
        {
            DBservices dbs = new DBservices();
            return dbs.ReadIngredient();//"הפעלת פו שנמצאת שמחלקה "שירותי דטהביס
        }

        public bool Insert()
        {//הכנסה
            DBservices dbs = new DBservices();
            List<Ingredient> IngredientList = dbs.ReadIngredient();
            foreach (Ingredient Ingredient in IngredientList) //בדיקה האם הדירה קיימת
            {
                if (this.Name == Ingredient.Name)
                {
                    return false;
                }
            }
            dbs.InsertIngredient(this);//"הפעלת פו שנמצאת שמחלקה "שירותי דטהביס
            return true;
        }
    }
}
