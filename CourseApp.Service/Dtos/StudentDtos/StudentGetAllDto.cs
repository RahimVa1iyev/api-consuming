namespace CourseApp.Service.Dtos.StudentDtos
{
    public class StudentGetAllDto
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public string ImageUri { get; set; }

        public GroupInStudentGetAllDto Group { get; set; }
    }


    public class GroupInStudentGetAllDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
