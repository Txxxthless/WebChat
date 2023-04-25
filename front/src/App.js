import "./App.css";
import "./components/Chat";
import Chat from "./components/Chat";
import Register from "./components/Registration";
import NavBar from "./components/NavBar";

function App() {
  return (
    <div className="App">
      <NavBar />
      <Register />
    </div>
  );
}

export default App;
