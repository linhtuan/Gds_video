using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("PaymentLog")]
    public class PaymentLog
    {
        [Key]
        public int PaymentLogId { get; set; }

        public int UserId { get; set; }

        public int CategoryTypeId { get; set; }

        public decimal NumberPrice { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
