import React from 'react';
import FCIngredient from "./FCIngredient";

export default function FCIngredients(props) {

    // מעבר על מערך המתכונים והעברת כל מתכון למחלקת המטבחשלי שטרנדר את הפרטים של המתכונים
    let FCIngredientsStr = props.IngredientsList.map((ingredient, ind) => {
        return <FCIngredient
            id={ingredient.id}
            image={ingredient.image}
            name={ingredient.name}
            calories={ingredient.calories}
            /* button={props.button} */
            key={ingredient.id}
            onRemove={() => props.onRemove(ingredient.id)}
            onAdd={() => props.onAdd(ingredient.id)}
            added={props.added}
            />;
    })


    return (
        <div className="row List">
            {FCIngredientsStr}
        </div>
    );

}
