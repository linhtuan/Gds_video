using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorDetail { get; set; }

        public string AuthorImage { get; set; }

        [NotMapped]
        public string ThumbnailImage { get; set; }

        [NotMapped]
        public string MimeTypeImage { get; set; }
    }
}
