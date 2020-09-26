import React from "react";
import "./App.css";
import LikeButton from "./components/like/likeButton";

function App() {
  return (
    <div className="App">
      <h3>For this example I've used a fixed article id</h3>
      <pre>2ae90450-9040-4f3d-900b-cd7565a1225c</pre>
      You can use that to like an article with{" "}
      <pre>
        POST
        http://localhost/api/v1/articles/2ae90450-9040-4f3d-900b-cd7565a1225c/likes
      </pre>
      or to get the likes count with{" "}
      <pre>
        GET
        http://localhost/api/v1/articles/2ae90450-9040-4f3d-900b-cd7565a1225c/likes
      </pre>
      <br />
      <LikeButton articleId={"2ae90450-9040-4f3d-900b-cd7565a1225c"} />
    </div>
  );
}

export default App;
