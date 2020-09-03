using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name ="نقش")]
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید")]
        [MaxLength(100,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
