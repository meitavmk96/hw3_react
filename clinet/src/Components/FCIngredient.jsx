import React, { useState } from 'react';

export default function FCIngredient(props) {

    const handleChange = (e) => {
        if (e.target.checked) {
            props.onAdd(e.target.id);
        }
        else {
            props.onRemove(e.target.id);
        }
    };

    return (
        <div className="card col-12 col-sm-6 col-md-4">
            {props.added && <div>Add: <input type="checkbox" onChange={handleChange} id={props.id} /></div>}
            <div className="card-img"><img src={props.image} alt="could not load picture" className="img" /></div>
            <div><h3>{props.name}</h3></div>
            <div><h5>{props.calories}</h5></div>
        </div>
    )
}
