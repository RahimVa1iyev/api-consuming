using System.ComponentModel.DataAnnotations;

namespace CourseApp.UI.ViewModel
{
    public class StudentCreateVM
    {

        public int GroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }

        [Range(0, int.MaxValue)]

        public decimal Point { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
