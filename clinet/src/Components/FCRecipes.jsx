import React from 'react';
import FCRecipe from "./FCRecipe";

export default function FCRecipes(props) {

    // מעבר על מערך המתכונים והעברת כל מתכון למחלקת המטבחשלי שטרנדר את הפרטים של המתכונים
    let RecipesStr = props.RecipesList.map((recipe, ind) => {
        return <FCRecipe
            id={recipe.id}
            image={recipe.image}
            name={recipe.name}
            cookingMethod={recipe.cookingMethod}
            time={recipe.time}
            key={recipe.id}
           />;
    })


    return (
        <div className="row List">
            {RecipesStr}
        </div>
    );

}
