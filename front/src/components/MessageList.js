import React, { useEffect, useState } from "react";
import axios from "axios";

function MessageList() {
  const [messages, setMessages] = useState([]);
  const apiEndpoint = "http://localhost:5093/api/Message/GetMessages";

  useEffect(() => {
    const token = localStorage.getItem("token");
    axios.defaults.headers.common.Authorization = `Bearer ${token}`;
    axios
      .get(apiEndpoint)
      .then((result) => {
        setMessages(result.data);
        console.log(result.data);
      })
      .catch((error) => console.error(error));
  });

  return (
    <div className="row">
      <div className="col-md-10">
        <ul className="list-group list-group-flush chat-msg-list">
          {messages.map((message) => (
            <li className="list-group-item chat-list-item" key={message.id}>
              <small style={{ color: "#fa911c" }}>
                {message.timeOfCreation}
              </small>
              <h5>{message.text}</h5>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default MessageList;
