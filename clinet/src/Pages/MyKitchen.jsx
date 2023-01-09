import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState, useEffect } from 'react';
import FCRecipes from "../Components/FCRecipes";

const apiUrlRec = "https://localhost:7150/api/Recipes/";

export default function MyKitchen() {

  const [recipes, setRecipes] = useState([]);

  //--------------------------GET Recipes----------------------------

  //פו רצה פעם אחת אחרי הרנדר הראשון
  useEffect(() => {
    console.log('component did mount');
    fetch(apiUrlRec, { //של השרת URL
      method: 'GET',//מה המתודה
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);//הצגתו
        console.log('res.status', res.status);//הסטטוס שלו
        console.log('res.ok', res.ok);//לשאול אם הסטטוס הוא אוקי - בולייאני 
        return res.json()
      })
      .then(
        (result) => {
          setRecipes(result);
          console.log("fetch btnFetchGetStudents= ", result); //אובייקט
        },
        (error) => {//אם התבצע שגיאה
          console.log("err post=", error);
        });
  }, [])


  return (
    <div>
      <div><h1>My Recipe</h1></div>
      <FCRecipes RecipesList={recipes} />
    </div>
  )
}

