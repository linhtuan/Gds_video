using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("CategoryTypePrice")]
    public class CategoryTypePrice
    {
        [Key]
        public int CategoryTypePriceId { get; set; }

        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }

        public DateTime? SaleTime { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
