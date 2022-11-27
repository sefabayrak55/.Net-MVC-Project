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
        public string CategoryName { get; set; }

        public string Description { get; set; }


    }
}
