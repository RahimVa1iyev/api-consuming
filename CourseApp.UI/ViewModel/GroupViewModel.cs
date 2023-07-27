namespace CourseApp.UI.ViewModel
{
    public class GroupViewModel
    {
      public  List<GroupViewModelItem> Groups { get; set; } = new List<GroupViewModelItem>();
    }

    public class GroupViewModelItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
