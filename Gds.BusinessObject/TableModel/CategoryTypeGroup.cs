using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("CategoryTypeGroup")]
    public class CategoryTypeGroup
    {
        [Key]
        public int CategoryTypeGroupId { get; set; }

        public int CategoryTypeId { get; set; }

        public string CategoryTypeGroupName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Index { get; set; }
    }
}
