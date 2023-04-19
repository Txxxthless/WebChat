import React, { useEffect, useState } from "react";
import axios from "axios";

function MessageList() {
  const [messages, setMessages] = useState([]);
  const apiEndpoint = "https://jsonplaceholder.typicode.com/users";

  useEffect(() => {
    axios
      .get(apiEndpoint)
      .then((result) => {
        setMessages(result.data);
      })
      .catch((error) => console.error(error));
  }, []);

  return (
    <div className="row">
      <div className="col-md-10">
        <ul className="list-group list-group-flush chat-msg-list">
          {messages.map((message) => (
            <li className="list-group-item chat-list-item" key={message.id}>
              {message.name}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default MessageList;
