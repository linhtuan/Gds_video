using System.Collections.Generic;

namespace GiaoDucSomVideo.Models
{
    public class CategoryHomeViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<CategoryTypeHomeViewModel> CategoryTypes { get; set; } 
    }

    public class CategoryTypeHomeViewModel
    {
        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }
        
        public string CategoryTypeName { get; set; }

        public string ThumbnailImage { get; set; }

        public string MimeTypeImage { get; set; }

        public string CategoryTypeUrl { get; set; }
    }
}