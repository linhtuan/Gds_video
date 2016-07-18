using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gds.BusinessObject.TableModel
{
    [Serializable]
    [Table("Role")]
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
