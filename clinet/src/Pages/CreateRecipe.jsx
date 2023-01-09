import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState, useEffect } from 'react';
import FCIngredients from "../Components/FCIngredients";

const apiUrlRec = "https://localhost:7150/api/Recipes/";
const apiUrlIng = "https://localhost:7150/api/Ingredients/";

export default function CreateRecipe() {

  //---------------Get Ingredients------------------------------

  const [ingredients, setIngredients] = useState([]);

  //פו רצה פעם אחת אחרי הרנדר הראשון
  useEffect(() => {
    console.log('component did mount');
    fetch(apiUrlIng, { //של השרת URL
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
          setIngredients(result);
          console.log("fetch btnFetchGetStudents= ", result); //אובייקט
        },
        (error) => {//אם התבצע שגיאה
          console.log("err post=", error);
        });
  }, [])


  //---------------------------------POST Recipes-------------------------------------------------


  //יצירת הסטייט התחלתי
  const [recpieName, setRecpieName] = useState("");
  const [recpieImg, setRecpieImg] = useState("");
  const [recpieCookingMethod, setRecpieCookingMethod] = useState("");
  const [recpieCookingTime, setRecpieCookingTime] = useState("");

  let recpieIngerdaintsId = [];

  const handleAdd = (id) => {
    recpieIngerdaintsId.push(id);
  };
  const handleRemove = (id) => {
    recpieIngerdaintsId = recpieIngerdaintsId.filter((item) => item !== id);
  };


  const AddRecipe = (e) => {

    e.preventDefault();

    const Rec = { //יצירת אובייקט לפי השדות במחלקה
      Name: recpieName,
      Image: recpieImg,
      CookingMethod: recpieCookingMethod,
      Time: recpieCookingTime
    };

    if (recpieIngerdaintsId.length === 0) {
      alert("Error, please add ingredients for recpie");
      return;
    }
    fetch(apiUrlRec, {
      method: 'POST',
      body: JSON.stringify(Rec), //bodyשליחת אובייקט ב 
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8',//חשוב - JSON לשלוח
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(response => {
        console.log('res=', response);
        return response.json()
      })
      .then(
        (result) => {//body
          PostIngredientForRecipe(result);
          alert("Success");
        },
        (error) => {
          console.log("err post=", error);
        });


    //-----------------POST Ingredient For Recipe-------------------------
    const PostIngredientForRecipe = (id) => {

      for (let i = 0; i < recpieIngerdaintsId.length; i++) {

        const apiUrl = `https://localhost:7150/api/Recipes/PostIngredientForRecipe/${id}?ingredientId=${recpieIngerdaintsId[i]}`;

        fetch(apiUrl, {
          method: 'POST',
          headers: new Headers({
            'Content-type': 'application/json; charset=UTF-8',//חשוב - JSON לשלוח
            'Accept': 'application/json; charset=UTF-8',
          })
        })
          .then(response => {
            console.log('res=', response);
            return response.json()
          })
          .then(
            (result) => {//body
              console.log("err post=", result);
            },
            (error) => {
              console.log("err post=", error);
            });
      }
    }
  }

  return (
    <div>
      <h1>New Recipe</h1>
      <div className="row">
        <div className="col form">
          <form onSubmit={AddRecipe}>
            <div className="row">
              <div className="col"></div>

              <div className="col">
                <div className="form-group">
                  <label className="form-label">name: </label>
                  <input placeholder="enter recipe name" type="text" className="form-control" name="name" onChange={(e) => setRecpieName(e.target.value)} required />
                </div>
                <div className="form-group">
                  <label className="form-label">image: </label>
                  <input placeholder="enter image url" type="text" className="form-control" name="image" onChange={(e) => setRecpieImg(e.target.value)} required />
                </div>
                <div className="form-group">
                  <label className="form-label">cooking method: </label>
                  <input placeholder="enter cooking method" type="text" className="form-control" name="cookingMethod" onChange={(e) => setRecpieCookingMethod(e.target.value)} required />
                </div>
                <div className="form-group">
                  <label className="form-label">time: </label>
                  <input placeholder="enter cooking time" type="number" className="form-control" name="time" min={1} onChange={(e) => setRecpieCookingTime(e.target.value)} required />
                </div>
                <br />
              </div>
              <div className="col"></div>
            </div>

            <div><FCIngredients IngredientsList={ingredients} onAdd={handleAdd} onRemove={handleRemove} added={true} /></div>
            <input type="submit" value="Create" className="btn" />
            <input type="reset" value="Clear" className="btn" />
          </form>
        </div>
      </div>
    </div>
  )
}
