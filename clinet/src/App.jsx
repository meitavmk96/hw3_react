import './App.css';
import { Routes, Route, Link } from 'react-router-dom';
import MyKitchen from './Pages/MyKitchen';
import CreateIngredient from './Pages/CreateIngredient';
import CreateRecipe from './Pages/CreateRecipe';




function App() {

  

  return (
    <div className="App">
       <div id="link">
        <Link to="/">My kitchen</Link> |
        <Link to="/CreateIngredient">Create new ingredient</Link> |
        <Link to="/CreateRecipe">Create new recipe</Link>
      </div>
      <header className="App-header">
      <Routes>
          <Route path="/" element={<MyKitchen />} />
          <Route path="/CreateIngredient" element={<CreateIngredient />} />
          <Route path="/CreateRecipe" element={<CreateRecipe />} />
          {/* <Route path="/user/:userid" element={<User />} /> */}
        </Routes>
      </header>
    </div>
  );
}

export default App;
