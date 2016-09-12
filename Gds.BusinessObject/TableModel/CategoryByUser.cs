using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("CategoryByUser")]
    public class CategoryByUser
    {
        public int CategoryByUserId { get; set; }

        public int CategoryTypeId { get; set; }

        public int UserId { get; set; }
            
    }
}
