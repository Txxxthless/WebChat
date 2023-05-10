import React from "react";
import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Loader from "../loader/Loader";

function Login() {
  const apiEndpoint = "http://localhost:5093/api/Auth/Login";
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const [errors, setErrors] = useState({});
  const [isLoading, setIsLoading] = useState(false);

  const validate = () => {
    const errors = {};
    errors.canBeSend = true;
    if (!name) {
      errors.username = "Username is required";
      errors.canBeSend = false;
    }
    if (!password) {
      errors.password = "Password is required";
      errors.canBeSend = false;
    }
    console.log(errors);
    return errors;
  };

  const login = () => {
    setIsLoading(true);

    const loginViewModel = {
      name: name,
      password: password,
    };

    const errors = validate();
    setErrors(errors);

    if (errors.canBeSend) {
      axios
        .post(apiEndpoint, loginViewModel)
        .then((response) => {
          if (response.status === 200) {
            localStorage.setItem("token", response.data);
            navigate("/");
          }
        })
        .catch((error) => {
          console.log(error);
          setErrors({ ...error, login: "Incorrect username or password" });
        })
        .finally(() => setIsLoading(false));
    } else {
      setIsLoading(false);
    }
  };

  return (
    <form
      onSubmit={(event) => event.preventDefault()}
      className="card log-reg-card"
    >
      {isLoading ? (
        <Loader />
      ) : (
        <div className="row">
          <h1 className="text-white">Login</h1>
          <p className="chat-error-msg">{errors.login}</p>
          <h2 className="text-white">Name</h2>
          <input
            className="form-control log-reg-input form-control-lg"
            type="text"
            placeholder="Enter your name..."
            onChange={(event) => setName(event.target.value)}
          ></input>
          <p className="chat-error-msg">{errors.username}</p>
          <h2 className="text-white">Password</h2>
          <input
            className="form-control log-reg-input form-control-lg"
            type="password"
            placeholder="Enter password..."
            onChange={(event) => setPassword(event.target.value)}
          ></input>
          <p className="chat-error-msg">{errors.password}</p>
          <div>
            <button
              className="btn btn-light btn-lg align-text-bottom log-reg-btn"
              onClick={() => login()}
            >
              Login!
            </button>
          </div>
        </div>
      )}
    </form>
  );
}

export default Login;
