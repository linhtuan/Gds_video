using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("FeedbackComment")]
    public class FeedbackComment
    {
        [Key]
        public int FeedbackId { get; set; }

        public int CommentId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string CommentContent { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
