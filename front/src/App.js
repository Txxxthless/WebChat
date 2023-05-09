import { Routes, Route } from "react-router-dom";
import Chat from "./components/chat/Chat";
import Login from "./components/login/Login";
import Register from "./components/register/Registration";
import Layout from "./components/Layout";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Chat />} />
          <Route path="login" element={<Login />} />
          <Route path="register" element={<Register />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
