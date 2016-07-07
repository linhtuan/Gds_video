
namespace Gds.ServiceModel.BackEndModel
{
    public class CategoryDetailModel
    {
        public int CategoryDetailId { get; set; }

        public int CategoryTypeId { get; set; }

        public string CategoryDetailName { get; set; }

        public int PhysicalFileId { get; set; }

        public string Content { get; set; }

        public string UpdatedDate { get; set; }

        public int? Status { get; set; }

        public string FileName { get; set; }

        public PhysicalFileModel PhysicalFile { get; set; }
    }
}
