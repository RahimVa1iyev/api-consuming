namespace CourseApp.Service.Dtos.StudentDtos
{
    public class StudentGetDto
    {
        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public string ImageUri { get; set; }

        public GroupInStudentGetDto Group { get; set; }
    }

    public class GroupInStudentGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
