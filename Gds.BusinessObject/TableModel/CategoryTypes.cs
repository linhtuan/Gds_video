using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Table("CategoryTypes")]
    public class CategoryTypes
    {
        [Key]
        public int CategoryTypeId { get; set; }

        public int CategoryTypeParentId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTypeName { get; set; }

        public int? ContentType { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CategoryTypePriceId { get; set; }

        public string ThumbnailImage { get; set; }

        public int Status { get; set; }

        public string UrlRouter { get; set; }
    }
}
