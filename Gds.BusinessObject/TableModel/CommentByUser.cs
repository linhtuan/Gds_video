using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("CommentByUser")]
    public class CommentByUser
    {
        [Key]
        public int CommentByUserId { get; set; }

        public int CategoryTypeId { get; set; }

        public int UserId { get; set; }

        public string CommentContent { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
