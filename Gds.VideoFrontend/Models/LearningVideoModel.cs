using System.Collections.Generic;

namespace Gds.VideoFrontend.Models
{
    public class LearningVideoModel
    {
        public string CategoryTypeName { get; set; }

        public string CategoryTypeId { get; set; }

        public List<CategoryTypesParentModel> CategoryTypesParentModel { get; set; }
    }
}