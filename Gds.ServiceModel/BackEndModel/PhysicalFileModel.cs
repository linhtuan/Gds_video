using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gds.ServiceModel.BackEndModel
{
    public class PhysicalFileModel
    {
        public int PhysicalFileId { get; set; }

        public string FileName { get; set; }

        public string FileTime { get; set; }

        public string CreatedDate { get; set; }
    }
}
