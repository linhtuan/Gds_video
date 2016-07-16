namespace Gds.VideoFrontend.Models
{
    public class CoursesViewModel
    {
        public int Type { get; set; }//0 hot, 1 default

        public string CourseName { get; set; }

        public string ThumbnailImage { get; set; }

        public string MimeTypeImage { get; set; }

        public string UrlCourse { get; set; }

        public string Price { get; set; }
    }
}