import React from "react";
import MessageList from "./MessageList";
import InputMessage from "./InputMessage";

function Chat() {
  return (
    <div
      className="row flex-fill fill d-flex justify-content-start"
      style={{ backgroundColor: "#3c3f58", padding: "50px" }}
    >
      <h1 style={{ color: "white" }}>Wellcome to WebChat!</h1>
      <div
        className="card"
        style={{
          borderRadius: "10px",
          height: "contain",
          backgroundColor: "#43455c",
          marginLeft: "10px",
          marginRight: "10px",
        }}
      >
        <MessageList />
      </div>
      <InputMessage />
      <div style={{ height: "25.8em" }}></div>
    </div>
  );
}

export default Chat;
