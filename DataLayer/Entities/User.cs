using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        [Display(Name ="نام")]
        [MaxLength(50,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Name { get; set; }
        [Display(Name ="نام خانوادگی")]
        [MaxLength(50,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string LastName { get; set; }
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید")]
        [MaxLength(50,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Email { get; set; }
        [Display(Name ="رمز")]
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید")]
        [MaxLength(50,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string PassWord { get; set; }
        [Display(Name ="عکس")]
        [MaxLength(150,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Pic { get; set; }
        [Display(Name ="تاریخ عضویت")]
        [Required(ErrorMessage ="لطفا مقدار را وارد کنید")]
        [MaxLength(20,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string DateCreate { get; set; }

        public virtual Role Role { get; set; }
        public virtual  ICollection<Article> Articles { get; set; }
    }
}
