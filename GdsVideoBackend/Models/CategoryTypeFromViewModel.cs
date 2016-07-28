using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GdsVideoBackend.Models
{
    public class CategoryTypeFromViewModel
    {
        public List<PriceSetting> PriceSetting { get; set; }

        public List<AgeOrderSetting> AgeOrderSetting { get; set; }

        public List<AuthorSetting> AuthorSettings { get; set; }
    }

    public class PriceSetting
    {
        public int Id { get; set; }
        
        public decimal? Price { get; set; }
    }

    public class AgeOrderSetting
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AuthorSetting
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}