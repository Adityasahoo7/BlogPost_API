using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Models.Data.DTOs.BlogpostDTO
{
    public class ViewBlogpostAdminDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public bool Isvisible { get; set; }
    }
}
