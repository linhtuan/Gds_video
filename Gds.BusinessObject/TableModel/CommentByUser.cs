using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int? CategoryTypeId { get; set; }

        public int? CategoryDetailId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string CommentContent { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
