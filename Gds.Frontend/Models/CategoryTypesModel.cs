using System.Collections.Generic;

namespace Gds.Frontend.Models
{
    public class CategoryTypesParentModel
    {

        public int CategoryTypeIndex { get; set; }

        public string CategoryTypeParentName { get; set; }

        public List<CategoryDetailModel> CategoryDetails { get; set; }
    }

    public class CategoryDetailModel
    {
        public string Name { get; set; }

        public string UrlLecture { get; set; }

    }
}