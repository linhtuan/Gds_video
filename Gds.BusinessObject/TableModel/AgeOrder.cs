using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Table("AgeOrder")]
    public class AgeOrder
    {
        [Key]
        public int AgeOrderId { get; set; }

        public string AgeOrderName { get; set; }
    }
}
