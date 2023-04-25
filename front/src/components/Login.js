import React from "react";
import { useState } from "react";
import axios from "axios";

function Login() {
  const apiEndpoint = "http://localhost:5093/api/Auth/Login";
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");

  const login = () => {
    const loginViewModel = {
      name: name,
      password: password,
    };

    axios
      .post(apiEndpoint, loginViewModel)
      .then((response) => {
        const token = response.data;
        localStorage.setItem("token", token);
        window.location.href = "/";
      })
      .catch((error) => console.log(error));
  };

  return (
    <div className="card log-reg-card">
      <div className="row">
        <h1 className="text-white">Login</h1>
        <h2 className="text-white">Name</h2>
        <input
          className="form-control log-reg-input form-control-lg"
          type="text"
          placeholder="Enter your name..."
          onChange={(event) => setName(event.target.value)}
        ></input>
        <h2 className="text-white">Password</h2>
        <input
          className="form-control log-reg-input form-control-lg"
          type="password"
          placeholder="Enter password..."
          onChange={(event) => setPassword(event.target.value)}
        ></input>
        <div>
          <button
            className="btn btn-light btn-lg align-text-bottom log-reg-btn"
            onClick={() => login()}
          >
            Login!
          </button>
        </div>
      </div>
    </div>
  );
}

export default Login;
