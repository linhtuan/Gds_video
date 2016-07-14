using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("PhysicalFiles")]
    public class PhysicalFiles
    {
        [Key]
        public int PhysicalFileId { get; set; }

        public string FileName { get; set; }

        public string FileServerNamePath { get; set; }

        public long FileTime { get; set; }

        public long FileLength { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
