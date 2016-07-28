
namespace GdsVideoBackend.Models
{
    public class CategoryTypeViewModel
    {
        public int ParentId { get; set; }

        public int CategoryTypeId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTypeName { get; set; }

        public int? CategoryTypePriceId { get; set; }

        public string FileThumbnail { get; set; }

        public string Content { get; set; }

        public int AgeOrderId { get; set; }

        public int CategoryTypeOrderId { get; set; }

        public int AuthorId { get; set; }
    }
}