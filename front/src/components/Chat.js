import React, { useEffect } from "react";
import MessageList from "./MessageList";
import InputMessage from "./InputMessage";

function Chat() {
  useEffect(() => {
    if (
      localStorage.getItem("token") === "NO_TOKEN" ||
      !localStorage.getItem("token")
    ) {
      window.location.href("/login");
    }
  }, []);
  return (
    <div className="row flex-fill fill d-flex justify-content-start outer-card">
      <h1 style={{ color: " white" }}>Wellcome to WebChat!</h1>
      <div className="card inner-card">
        <MessageList />
      </div>
      <InputMessage />
    </div>
  );
}

export default Chat;
