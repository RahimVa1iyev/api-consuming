using System.ComponentModel.DataAnnotations;

namespace CourseApp.UI.ViewModel
{
    public class GroupEditVM
    {
        [Required]
        [MaxLength(20)]
        [MinLength(4)]

        public string Name { get; set; }
    }
}
