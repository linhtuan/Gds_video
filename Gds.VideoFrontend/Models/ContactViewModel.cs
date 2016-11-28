namespace Gds.VideoFrontend.Models
{
    public class ContactViewModel
    {
        public string SecurityCode { get; set; }

        public string TokenUser { get; set; }

        public int ContactId { get; set; }

        public string ContactName { get; set; }

        public string ContactFullName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactImage { get; set; }

        public string ContactGender { get; set; }

        public decimal ContactGold { get; set; }

        public string ContactBirthday { get; set; }

        public string Message { get; set; }

        public int TotalCourse { get; set; }
    }
}