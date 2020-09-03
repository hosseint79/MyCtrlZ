using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [Display(Name ="سطح دسترسی")]
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید")]
        [MaxLength(100,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string PermissionName { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
