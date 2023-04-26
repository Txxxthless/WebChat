import React, { useState, useRef } from "react";
import axios from "axios";

function Register() {
  const apiEndpoint = "http://localhost:5093/api/Auth/Register";
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");

  const passwordRef = useRef();
  const passwordConfirmRef = useRef();

  const register = () => {
    if (passwordRef.current.value === passwordConfirmRef.current.value) {
      const registerViewModel = {
        name: name,
        password: password,
      };
      console.log(registerViewModel);
      axios
        .post(apiEndpoint, registerViewModel)
        .then((response) => {
          const token = response.data.token;
          localStorage.setItem("token", token);
          const username = response.data.username;
          localStorage.setItem("username", username);
          window.location.href = "/";
        })
        .catch((error) => console.log(error));
    } else {
      return;
    }
  };

  return (
    <div className="card log-reg-card">
      <div className="row">
        <h1 className="text-white">Registration</h1>
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
          ref={passwordRef}
        ></input>
        <h2 className="text-white">Repeat password</h2>
        <input
          className="form-control log-reg-input form-control-lg"
          type="password"
          placeholder="Repeat password..."
          ref={passwordConfirmRef}
        ></input>
        <div>
          <button
            className="btn btn-light btn-lg align-text-bottom log-reg-btn"
            onClick={() => register()}
          >
            Register!
          </button>
        </div>
      </div>
    </div>
  );
}

export default Register;
