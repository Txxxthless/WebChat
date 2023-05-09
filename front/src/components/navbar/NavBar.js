import React from "react";
import { Link } from "react-router-dom";
import GitHubIcon from "./navbar-icons/GitHubIcon";
import LoginIcon from "./navbar-icons/LoginIcon";
import RegisterIcon from "./navbar-icons/RegisterIcon";
import LogoutIcon from "./navbar-icons/LogoutIcon";

function NavBar(props) {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light chat-nav">
      <Link className="navbar-brand" to="/">
        WebChat
      </Link>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>

      <div className="collapse navbar-collapse " id="navbarSupportedContent">
        <ul className="navbar-nav mr-auto">
          <li className="nav-item active">
            <a
              className="nav-link"
              href="https://github.com/Txxxthless/WebChat"
            >
              <GitHubIcon />
            </a>
          </li>
          <li className="nav-item active">
            <Link className="nav-link" to="/login">
              <LoginIcon />
            </Link>
          </li>
          <li className="nav-item active">
            <Link className="nav-link" to="/register">
              <RegisterIcon />
            </Link>
          </li>
          <li className="nav-item active">
            <Link onClick={() => props.logout()} className="nav-link" to="/">
              <LogoutIcon />
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default NavBar;
