import React from "react";
import { useNavigate } from "react-router-dom";
import NavBar from "./navbar/NavBar";
import { Outlet } from "react-router-dom";

function Layout() {
  const navigate = useNavigate();

  const logout = () => {
    localStorage.removeItem("token");
    navigate("/");
  };

  return (
    <>
      <NavBar logout={logout} />
      <Outlet />
    </>
  );
}

export default Layout;
