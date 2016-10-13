using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gds.VideoFrontend.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string UserName { get; set; }

        public string CommentContent { get; set; }

        public string CommentTime { get; set; }

        public List<FeedbackComment> FeedbackComments { get; set; } 
    }

    public class FeedbackComment
    {
        public string UserName { get; set; }

        public string CommentContent { get; set; }

        public string CommentTime { get; set; }
    }
}