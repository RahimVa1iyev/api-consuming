using System.ComponentModel.DataAnnotations;

namespace CourseApp.UI.ViewModel
{
    public class StudentEditVM
    {
        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }
      
        [Range(0, 100)]
        public decimal Point { get; set; }

        public int GroupId { get; set; }


        public IFormFile ImageFile { get; set; }

    }
}
