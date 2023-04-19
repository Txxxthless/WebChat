import React from "react";
import MessageList from "./MessageList";
import InputMessage from "./InputMessage";

function Chat() {
  return (
    <div className="row flex-fill fill d-flex justify-content-start outer-card">
      <h1 style={{ color: "white" }}>Wellcome to WebChat!</h1>
      <div className="card inner-card">
        <MessageList />
      </div>
      <InputMessage />
      <div style={{ height: "25.8em" }}></div>
    </div>
  );
}

export default Chat;
