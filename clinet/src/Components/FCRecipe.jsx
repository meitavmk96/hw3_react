import React, { useState, useEffect } from 'react';
import FCIngredients from "../Components/FCIngredients";

import 'react-responsive-modal/styles.css';
import { Modal } from 'react-responsive-modal';

export default function FCRecipe(props) {

  const apiUrlIng = `https://localhost:7150/api/Recipes/GetIngredientForRecipe/${props.id}`;

  //----------------------------Modal-------------------------------
  const [open, setOpen] = useState(false);
  const onOpenModal = () => setOpen(true);
  const onCloseModal = () => setOpen(false);

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


  return (
    <div className="card col-12 col-sm-6 col-md-4">
      <div className="card-img"><img src={props.image} alt="could not load picture" className="img" /></div>
      <div><h3>{props.name}</h3></div>
      <div><h5>{props.cookingMethod}</h5></div>
      <div><h5>{props.time}</h5></div>
      <div>
        <button className=".btn" onClick={onOpenModal} id={props.id}>ingredients details</button>
        <Modal open={open} onClose={onCloseModal} center>
          <h2>Ingredients:</h2>
          <div><FCIngredients IngredientsList={ingredients} added={false} /></div>
        </Modal>
      </div>
    </div>
  )
}
