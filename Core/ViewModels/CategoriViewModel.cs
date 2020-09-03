using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Core
{
    public class CategoriViewModel
    {
        [Display(Name = "نام گروه")]
        [MaxLength(60, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
