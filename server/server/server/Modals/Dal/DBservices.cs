using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using server.Modals;
using System.Net;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {
        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------Ingredient------------------------------------------------------
    //-------------------------------------------------------------------------------------------------
    //קריאה Read a ingredient to the ingredients table 
    //-------------------------------------------------------------------------------------------------
    public List<Ingredient> ReadIngredient() //קריאה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureRead("spReadIngredients", con);// create the command

        List<Ingredient> IngredientsList = new List<Ingredient>();//יצירת מערך סטודנטים

        try
        {
            //Cmd על בסיס ה Read ביצוע הפקודה - יצירת
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//Create a data reader
            while (dataReader.Read())
            {
                //איזה מערך מחזירים
                Ingredient ingredient = new Ingredient();
                //הכנסת הערכים והמרתם
                ingredient.Id = Convert.ToInt32(dataReader["Id"]);
                ingredient.Name = dataReader["Name"].ToString();
                ingredient.Image = dataReader["Image"].ToString();
                ingredient.Calories = Convert.ToInt32(dataReader["Calories"]);

                IngredientsList.Add(ingredient); //הכנסת האובייקט למערך
            }
            return IngredientsList;//החזרת המערך
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureRead(String spName, SqlConnection con)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure אין לה פרמטרים

        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    //הכנסה insert a ingredient to the ingredients table 
    //--------------------------------------------------------------------------------------------------
    public int InsertIngredient(Ingredient ingredient)//הכנסה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureInsertIngredient("spInsertIngredient", con, ingredient);// create the command

        try
        {
            //ביצוע הפקודה
            int numEffected = cmd.ExecuteNonQuery(); // החזרת מס הרשומות שהשתנו לטבלה
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureInsertIngredient(String spName, SqlConnection con, Ingredient ingredient)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure הפרמטרים שאנחנו שולחים ל
        cmd.Parameters.AddWithValue("@name", ingredient.Name);
        cmd.Parameters.AddWithValue("@image", ingredient.Image);
        cmd.Parameters.AddWithValue("@calories", ingredient.Calories);

        return cmd;
    }






    //-----------------------------------Recipe--------------------------------------------------------

    //-------------------------------------------------------------------------------------------------
    //קריאה Read a recipe to the recipes table 
    //-------------------------------------------------------------------------------------------------
    public List<Recipe> ReadRecipe() //קריאה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureReadRecipe("spReadRecipes", con);// create the command

        List<Recipe> RecipesList = new List<Recipe>();//יצירת מערך סטודנטים

        try
        {
            //Cmd על בסיס ה Read ביצוע הפקודה - יצירת
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//Create a data reader
            while (dataReader.Read())
            {
                //איזה מערך מחזירים
                Recipe recipe = new Recipe();
                //הכנסת הערכים והמרתם
                recipe.Id = Convert.ToInt32(dataReader["Id"]);
                recipe.Name = dataReader["Name"].ToString();
                recipe.Image = dataReader["Image"].ToString();
                recipe.CookingMethod = dataReader["CookingMethod"].ToString();
                recipe.Time = Convert.ToInt32(dataReader["Time"]);

                RecipesList.Add(recipe); //הכנסת האובייקט למערך
            }
            return RecipesList;//החזרת המערך
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureReadRecipe(String spName, SqlConnection con)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure אין לה פרמטרים

        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    //הכנסה insert a Recipe to the Recipes table 
    //--------------------------------------------------------------------------------------------------
    public int InsertRecipe(Recipe recipe)//הכנסה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureInsertRecipe("spInsertRecipe", con, recipe);// create the command

        try
        {
            //ביצוע הפקודה
            //idהחזרת ה
            int id = Convert.ToInt32(cmd.ExecuteScalar());// החזרת מס הרשומות שהשתנו לטבלה
            return id;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureInsertRecipe(String spName, SqlConnection con, Recipe recipe)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure הפרמטרים שאנחנו שולחים ל
        cmd.Parameters.AddWithValue("@name", recipe.Name);
        cmd.Parameters.AddWithValue("@image", recipe.Image);
        cmd.Parameters.AddWithValue("@cookingMethod", recipe.CookingMethod);
        cmd.Parameters.AddWithValue("@time", recipe.Time);

        return cmd;
    }



    //-----------------------------------Recipe&Ingredient----------------------------------------------

    //-------------------------------------------------------------------------------------------------
    //קריאה Read a recipe to the recipes table 
    //-------------------------------------------------------------------------------------------------
    public List<Ingredient> ReadIngredientForRecipe(int recipeId) //קריאה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureReadIngredientForRecipe("spReadRecipeIngredient", con, recipeId);// create the command

        List<Ingredient> IngredientsList = new List<Ingredient>();//יצירת מערך סטודנטים

        try
        {
            //Cmd על בסיס ה Read ביצוע הפקודה - יצירת
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//Create a data reader
            while (dataReader.Read())
            {
                //איזה מערך מחזירים
                Ingredient ingredient = new Ingredient();
                //הכנסת הערכים והמרתם
                ingredient.Id = Convert.ToInt32(dataReader["Id"]);
                ingredient.Name = dataReader["Name"].ToString();
                ingredient.Image = dataReader["Image"].ToString();
                ingredient.Calories = Convert.ToInt32(dataReader["Calories"]);

                IngredientsList.Add(ingredient); //הכנסת האובייקט למערך
            }
            return IngredientsList;//החזרת המערך
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureReadIngredientForRecipe(String spName, SqlConnection con, int recipeId)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure שולחים לה פרטמטר
        cmd.Parameters.AddWithValue("@recipeId", recipeId);

        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    //הכנסה insert a Recipe&Ingredient to the Recipes&Ingredients table 
    //--------------------------------------------------------------------------------------------------
    public int InsertIngredientForRecipe(int recipeId, int ingredientId)//הכנסה
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithStoredProcedureInsertIngredientForRecipe("spInsertRecipeIngredient", con, recipeId, ingredientId);// create the command

        try
        {
            //ביצוע הפקודה
            int numEffected = cmd.ExecuteNonQuery(); // החזרת מס הרשומות שהשתנו לטבלה
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommandWithStoredProcedureInsertIngredientForRecipe(String spName, SqlConnection con,int recipeId, int ingredientId)
    {
        //stored procedure

        //command יצירת אובייקט מטיפוס
        SqlCommand cmd = new SqlCommand();

        //העברה לאובייקט את ההתחברות שיצרנו - con
        cmd.Connection = con;

        // can be Select, Insert, Update, Delete 
        // stored procedure ההעברה לאובייקט את השם של 
        cmd.CommandText = spName;

        // The default is 30 seconds
        // הגדרת הזמן שמחכים שהפקודה תתבצע
        cmd.CommandTimeout = 10;

        //stored procedure - טיפוס הפקודה שיצרנו
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //stored procedure הפרמטרים שאנחנו שולחים ל
        cmd.Parameters.AddWithValue("@recipeId", recipeId);
        cmd.Parameters.AddWithValue("@ingredientId", ingredientId);

        return cmd;
    }

}
