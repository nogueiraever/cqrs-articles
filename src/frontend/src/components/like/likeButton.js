import React, { useEffect, useState } from "react";
import articlesService from "../../services/articlesService";
import feedbackService from "../../services/feedbackService";
import "./likeButton.css";

export default function LikeButton({ articleId }) {
  const [likesCount, setLikesCount] = useState(0);

  useEffect(() => {
    const getLikes = async () => {
      try {
        const response = await articlesService.getLikes(articleId);
        if (response.status === 200) setLikesCount(response.data.data);
      } catch (error) {
        feedbackService.error(error);
      }
    };
    getLikes();
  }, []);

  const like = async () => {
    try {
      const response = await articlesService.like(articleId);
      if (response.status === 200) {
        setLikesCount((old) => old + 1);
      }
    } catch (error) {
      feedbackService.error(error);
    }
  };

  return (
    <>
      <i class="fa fa-thumbs-up" aria-hidden="true" onClick={like}></i>
      {likesCount > 0 && likesCount}
    </>
  );
}
