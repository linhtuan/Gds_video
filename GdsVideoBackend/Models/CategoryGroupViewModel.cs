using System.Collections.Generic;

namespace GdsVideoBackend.Models
{
    public class CategoryGroupViewModel
    {
        public int CategoryGroupId { get; set; }

        public string CategoryGroupName { get; set; }

        public List<CategoryDetailModel> CategoryDetails { get; set; }
    }
}