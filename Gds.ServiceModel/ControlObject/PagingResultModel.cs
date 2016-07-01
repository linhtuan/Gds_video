using System.Collections.Generic;

namespace Gds.ServiceModel.ControlObject
{
    public class PagingResultModel<T> where T : class
    {
        public IEnumerable<T> Result { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int ItemCount { get; set; }

        public int PageCount { get; set; }
    }
}
