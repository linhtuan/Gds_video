using System.Collections.Generic;

namespace Gds.Frontend.Models
{
    public class CategoryViewModel
    {
        public string Title { get; set; }

        public List<CategoryLeftMenuViewModel> LeftMenu { get; set; }

        public List<CoursesViewModel> CoursesHot { get; set; }

        public string CategoryRouter { get; set; }
    }
}