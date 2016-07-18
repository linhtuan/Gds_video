using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("CategoryRating")]
    public class CategoryRating
    {
        [Key]
        public int CategoryRatingId { get; set; }

        public int CategoryTypeId { get; set; }

        public int UserId { get; set; }

        public int Level { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
