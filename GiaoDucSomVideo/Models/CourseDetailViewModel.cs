﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoDucSomVideo.Models
{
    public class CourseDetailViewModel
    {
        public string CategoryName { get; set; }

        public string CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseSubTitle { get; set; }

        public string ThumbnailImage { get; set; }

        public string MimeTypeImage { get; set; }

        public string Price { get; set; }

        public string Content { get; set; }
    }
}