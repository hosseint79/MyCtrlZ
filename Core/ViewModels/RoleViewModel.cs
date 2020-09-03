using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Core
{
    public class RoleViewModel
    {
        [Display(Name = "نقش")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string RoleName { get; set; }
    }
}
