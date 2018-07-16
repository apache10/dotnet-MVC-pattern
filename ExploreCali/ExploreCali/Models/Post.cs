using System;
using System.ComponentModel.DataAnnotations;
namespace ExploreCali.Models
{
    public class Post
    {
        
        [Required]
        [StringLength(100, MinimumLength =5,
                      ErrorMessage ="required")]
        [Display (Name = "Post Title")]
        [DataType (DataType.Text)]
        public String Title { get; set; }
        public String Author { get; set; }
        [Required]
        [MinLength(100,ErrorMessage ="it should be minmum 100 character")]
        [DataType(DataType.MultilineText)]
        public String Body { get; set; }
        public DateTime Posted { get; set; }
        
    }
}
