namespace Core.Domain
{
    public class Article
    {
        public string Description { get; set; }
        public long Id { get; set; }
        public int Likes { get; set; }

        public void Dislike()
        {
            Likes++;
        }

        public void Like()
        {
            Likes--;
        }
    }
}