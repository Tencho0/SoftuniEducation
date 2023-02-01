import { Routes, Route } from 'react-router-dom';

import Header from './components/Header/Header';
import Home from './components/Home'
import Login from './components/Login/Login';
import { useEffect, useState } from "react";
import * as gameService from './services/gameService'
import Register from './components/Register/Register';
import Create from './components/Create/Create';
import Catalog from './components/Catalog/Catalog';
import './App.css';

function App() {
  const [games, setGames] = useState([]);
  useEffect(() => {
    gameService.getAll()
      .then(result => {
        setGames(result);
      })
  }, []);


  return (
    <div id="box">
      <Header />

      <main id="main-content">
        <Routes>
          <Route path="/" element={<Home games={games} />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/create" element={<Create />} />
          <Route path="/catalog" element={<Catalog games={games} />} />
        </Routes>
      </main>

      {/* Edit Page ( Only for the creator )*/}
      {/* <section id="edit-page" className="auth">
        <form id="edit">
          <div className="container">
            <h1>Edit Game</h1>
            <label htmlFor="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" defaultValue="" />
            <label htmlFor="category">Category:</label>
            <input type="text" id="category" name="category" defaultValue="" />
            <label htmlFor="levels">MaxLevel:</label>
            <input
              type="number"
              id="maxLevel"
              name="maxLevel"
              min={1}
              defaultValue=""
            />
            <label htmlFor="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" defaultValue="" />
            <label htmlFor="summary">Summary:</label>
            <textarea name="summary" id="summary" defaultValue={""} />
            <input className="btn submit" type="submit" defaultValue="Edit Game" />
          </div>
        </form>
      </section> */}

      {/*Details Page*/}
      {/* <section id="game-details">
        <h1>Game Details</h1>
        <div className="info-section">
          <div className="game-header">
            <img className="game-img" src="images/MineCraft.png" />
            <h1>Bright</h1>
            <span className="levels">MaxLevel: 4</span>
            <p className="type">Action, Crime, Fantasy</p>
          </div>
          <p className="text">
            Set in a world where fantasy creatures live side by side with humans. A
            human cop is forced to work with an Orc to find a weapon everyone is
            prepared to kill for. Set in a world where fantasy creatures live side
            by side with humans. A human cop is forced to work with an Orc to find a
            weapon everyone is prepared to kill for.
          </p>
          <div className="details-comments">
            <h2>Comments:</h2>
            <ul>
              <li className="comment">
                <p>Content: I rate this one quite highly.</p>
              </li>
              <li className="comment">
                <p>Content: The best game.</p>
              </li>
            </ul>
            <p className="no-comment">No comments.</p>
          </div>
          <div className="buttons">
            <a href="#" className="button">
              Edit
            </a>
            <a href="#" className="button">
              Delete
            </a>
          </div>
        </div>
        <article className="create-comment">
          <label>Add new comment:</label>
          <form className="form">
            <textarea
              name="comment"
              placeholder="Comment......"
              defaultValue={""}
            />
            <input
              className="btn submit"
              type="submit"
              defaultValue="Add Comment"
            />
          </form>
        </article>
      </section> */}
    </div>
  );
};

export default App;
