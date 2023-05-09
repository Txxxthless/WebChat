import React, { useRef } from "react";
import axios from "axios";

function InputMessage() {
  const inputRef = useRef(0);
  const apiEndpoint = "http://localhost:5093/api/Message/PostMessage";

  const sendMessageToApi = () => {
    const messageFromInput = inputRef.current.value;
    const message = {
      text: messageFromInput,
    };

    axios
      .post(apiEndpoint, message)
      .then((response) => console.log("posted", response))
      .catch(() => console.log("error"))
      .finally(() => {
        inputRef.current.value = "";
        inputRef.current.focus();
      });
  };

  return (
    <div className="row" style={{ marginTop: "15px" }}>
      <div className="col-md-8">
        <input
          type="text"
          className="form-control chat-input-field form-control-lg"
          placeholder="Type message"
          ref={inputRef}
        ></input>
      </div>
      <div className="col-md-4">
        <button
          className="btn btn-light btn-lg align-text-bottom chat-send-btn"
          onClick={() => sendMessageToApi()}
        >
          Send message!
        </button>
      </div>
    </div>
  );
}

export default InputMessage;
