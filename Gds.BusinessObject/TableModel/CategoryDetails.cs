using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Table("CategoryDetails")]
    public class CategoryDetails
    {
        [Key]
        public int CategoryDetailId { get; set; }

        public int CategoryTypeId { get; set; }

        public string CategoryDetailName { get; set; }

        public int PhysicalFileId { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? Status { get; set; }
    }
}
