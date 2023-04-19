import React, { useReducer, useRef } from "react";
import axios from "axios";

function InputMessage() {
  const inputRef = useRef(0);
  const apiEndpoint = "https://jsonplaceholder.typicode.com/users";

  const sendMessageToApi = () => {
    const message = inputRef.current.value;
    console.log(message);
    axios
      .post(apiEndpoint, message)
      .then((response) => console.log("posted", response))
      .catch((error) => console.error(error));
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
