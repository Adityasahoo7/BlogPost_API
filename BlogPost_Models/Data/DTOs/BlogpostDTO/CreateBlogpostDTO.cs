using BlogPost_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Models.Data.DTOs.BlogpostDTO
{
    public class CreateBlogpostDTO
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageURL { get; set; }
       // public DateTime DateCreated { get; set; }
        public string Auther { get; set; }
        public bool Isvisible { get; set; }
        public ICollection<Guid> Categotys { get; set; }
    }
}
