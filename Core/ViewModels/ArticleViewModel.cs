using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class ArticleViewModel
    {
        public string Text { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        [DataType(DataType.MultilineText)]
        public string Describtion { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        [Required(ErrorMessage = "لطفا مقدار را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "عکس")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string ArticlePicture { get; set; }
        [Display(Name = "نمایش اسلاید")]
        public bool ShowSlide { get; set; }
        [Display(Name = "زمان ثبت")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشد ")]
        public string CreateDate { get; set; }
        [Display(Name = "تعداد نمایش")]
        public int visit { get; set; }
    }
}
