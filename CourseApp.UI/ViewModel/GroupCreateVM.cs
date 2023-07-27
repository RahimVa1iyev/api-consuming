using System.ComponentModel.DataAnnotations;

namespace CourseApp.UI.ViewModel
{
    public class GroupCreateVM
    {
        [Required]
        [MaxLength(20)]
        [MinLength(4)]

        public string Name { get; set; }
    }
}
