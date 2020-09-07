using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Core
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Email { get; set; }
        [Display(Name = "رمز")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string PassWord { get; set; }
        [Display(Name = "تکرار رمز")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        [Compare("PassWord")]
        public string ConfirmPassword { get; set; }
    }
}
