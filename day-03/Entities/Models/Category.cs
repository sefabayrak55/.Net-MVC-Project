using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        public Category ()
        {

        }

        public Category(int ıd, string categoryName, string description)
        {
            Id = ıd;
            CategoryName = categoryName;
            Description = description;
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Category Name is Required!")]
        [MinLength(5, ErrorMessage = "CategoryName consist of 5 chacracter")]
        public string CategoryName { get; set; }

        public string Description { get; set; }


    }
}
