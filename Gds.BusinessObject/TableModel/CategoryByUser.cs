using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
