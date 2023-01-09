import "bootstrap/dist/css/bootstrap.min.css";
import React, { useState } from 'react';

const apiUrlIng = "https://localhost:7150/api/Ingredients/";

export default function CreateIngredient() {

  //יצירת הסטייט התחלתי
  const [ingerdaintName, setIngerdaintName] = useState("");
  const [IngerdaintImg, setIngerdaintImg] = useState("");
  const [ingerdaintCalories, setIngerdaintCalories] = useState("");

  const handleClearForm = (e) => {
    e.preventDefault();
    setIngerdaintName("");
    setIngerdaintImg("");
    setIngerdaintCalories("");
  };

  //-------------------------------POST Ingredients-----------------------------

  const AddIngerdaint = (e) => {

    e.preventDefault();

    const Ing = { //יצירת אובייקט לפי השדות במחלקה
      Name: ingerdaintName,
      Image: IngerdaintImg,
      Calories: ingerdaintCalories
    };

    fetch(apiUrlIng, {
      method: 'POST',
      body: JSON.stringify(Ing), //bodyשליחת אובייקט ב 
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
          if (result) {
            alert("Success, The Ingredient added");
          }
          else { alert("error, The Ingredient already exists") };
        },
        (error) => {
          console.log("err post=", error);
        });
  }

  return (
    <div>
      <h1>New Ingredient</h1>
      <div className="row">
        <div className="col"></div>
        <div className="col form">
          <form onSubmit={AddIngerdaint}>
            <div className="form-group">
              <label className="form-label">name: </label>
              <input placeholder="enter ingredient name" type="text" className="form-control" name="name" onChange={(e) => setIngerdaintName(e.target.value)} required />
            </div>
            <div className="form-group">
              <label className="form-label">image: </label>
              <input placeholder="enter image url" type="text" className="form-control" name="image" onChange={(e) => setIngerdaintImg(e.target.value)} required />
            </div>
            <div className="form-group">
              <label className="form-label">calories: </label>
              <input placeholder="enter dish calories" type="number" className="form-control" name="calories" min={1} onChange={(e) => setIngerdaintCalories(e.target.value)} required />
            </div>
            <input type="submit" value="Create" className="btn" />
            <input type="reset" value="Clear" className="btn" />
          </form>
        </div>
        <div className="col"></div>
      </div>
    </div>
  )
}
