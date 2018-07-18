using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ExploreCali.Models
{
    public class Post
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }
        
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
