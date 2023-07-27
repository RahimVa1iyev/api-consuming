namespace CourseApp.UI.ViewModel
{
    public class StudentVM
    {
        public List<StudentGetVM> Students { get; set; }
    }

    public class StudentGetVM
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public string ImageUri { get; set; }

        public StudentGroup Group { get; set; }
    }

    public class StudentGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
