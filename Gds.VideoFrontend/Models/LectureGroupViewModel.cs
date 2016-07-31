using System.Collections.Generic;

namespace Gds.VideoFrontend.Models
{
    public class LectureGroupViewModel
    {
        public int LectureGroupIndex { get; set; }

        public string LectureGroupName { get; set; }

        public List<LectureContainerViewModel> Lectures { get; set; }
    }

    public class LectureContainerViewModel
    {
        public int LectureNumberIndex { get; set; }

        public string LectureName { get;set; }

        public string LectureTime { get; set; }

        public string LectureUrl { get; set; }
    }
}