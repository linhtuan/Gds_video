namespace Gds.ServiceModel.BackEndModel
{
    public class CategoryTypesModel
    {
        public int CategoryId { get; set; }

        public int ParentId { get; set; }

        public string ParentName { get; set; }

        public int ChildrenId { get; set; }

        public string ChildrenName { get; set; }

        public string Content { get; set; }

        public int? PriceId { get; set; }

        public decimal Price { get; set; }

        public string DateTime { get; set; }

        public string ThumbnailImage { get; set; }

        public string MimeTypeImage { get; set; }

        public int? AgeOrderId { get; set; }

        public string AgeOrderName { get; set; }

        public int CategoryTpyeOrder { get; set; }
    }
}
