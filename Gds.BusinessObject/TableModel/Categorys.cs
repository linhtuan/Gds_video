using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("Categorys")]
    public class Categorys
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDetail { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Status { get; set; }

        public string UrlRouter { get; set; }

        [NotMapped]
        public string DateTime { get; set; }

        [NotMapped]
        public string RouterDetail { get; set; }
    }
}
