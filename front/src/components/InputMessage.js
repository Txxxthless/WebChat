import React from "react";

function InputMessage() {
  return (
    <div className="row" style={{ marginTop: "15px" }}>
      <div className="col-md-11">
        <input
          type="text"
          className="form-control form-control-lg"
          placeholder="Type message"
          style={{
            backgroundColor: "#707793",
            color: "white",
            border: "0px",
          }}
        ></input>
      </div>
      <div className="col-md-1">
        <button
          className="btn btn-light btn-lg align-text-bottom"
          style={{
            width: "100%",
            backgroundColor: "#3bba9c",
            color: "white",
            border: "0px",
          }}
        >
          Send
        </button>
      </div>
    </div>
  );
}

export default InputMessage;
