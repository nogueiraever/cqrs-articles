using System;

namespace Core.Domain
{
    public class Article
    {
        public Article()
        {
            Id = Guid.NewGuid();
        }

        public string Description { get; set; }
        public Guid Id { get; set; }
        public int Likes { get; set; }

        public void Dislike()
        {
            Likes--;
        }

        public void Like()
        {
            Likes++;
        }
    }
}