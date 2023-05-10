import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Loader from "../loader/Loader";

function Register() {
  const apiEndpoint = "http://localhost:5093/api/Auth/Register";
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const [errors, setErrors] = useState({});
  const navigate = useNavigate();
  const [isLoading, setIsLoading] = useState(false);

  const validate = () => {
    const errors = {};
    errors.canBeSend = true;
    if (!name) {
      errors.username = "Username is required";
      errors.canBeSend = false;
    } else if (name.length < 4) {
      errors.username = "Username must be more than 3 characters";
      errors.canBeSend = false;
    }
    if (!password) {
      errors.password = "Password is required";
      errors.canBeSend = false;
    } else if (password !== confirmPassword) {
      errors.confirmPassword = "Passwords don't match";
      errors.canBeSend = false;
    } else if (password.length < 4) {
      errors.password = "Password must be more than 3 characters";
      errors.canBeSend = false;
    }
    if (!confirmPassword) {
      errors.confirmPassword = "Repeat the password";
      errors.canBeSend = false;
    }
    return errors;
  };

  const register = () => {
    setIsLoading(true);

    const registerViewModel = {
      name: name,
      password: password,
    };

    const errors = validate();
    setErrors(errors);

    if (errors.canBeSend) {
      axios
        .post(apiEndpoint, registerViewModel)
        .then((response) => {
          if (response.status === 200) {
            localStorage.setItem("token", response.data);
            navigate("/");
          }
        })
        .catch((error) => {
          console.log(error);
          setErrors({ ...error, register: "Something went wrong" });
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
          <h1 className="text-white">Registration</h1>
          <p className="chat-error-msg">{errors.register}</p>
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
          <h2 className="text-white">Repeat password</h2>
          <input
            className="form-control log-reg-input form-control-lg"
            type="password"
            placeholder="Repeat password..."
            onChange={(event) => setConfirmPassword(event.target.value)}
          ></input>
          <p className="chat-error-msg">{errors.confirmPassword}</p>
          <div>
            <button
              className="btn btn-light btn-lg align-text-bottom log-reg-btn"
              onClick={() => register()}
            >
              Register!
            </button>
          </div>
        </div>
      )}
    </form>
  );
}

export default Register;
