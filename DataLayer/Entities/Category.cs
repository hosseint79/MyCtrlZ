using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name ="نام گروه")]
        [MaxLength(60,ErrorMessage ="مقدار {0} نباید بیشتر از {1} باشد ")]
        public string Name { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
