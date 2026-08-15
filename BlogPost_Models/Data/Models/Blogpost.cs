namespace BlogPost_API.Data.Models
{
    public class Blogpost
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageURL { get; set; }
        public DateTime DateCreated { get; set; }
        public string Auther { get; set; }
        public bool Isvisible { get; set; }

        //  public ICollection<Category> Categotys { get; set; }
        public ICollection<Category> Categotys { get; set; } = new List<Category>();
    }
}
