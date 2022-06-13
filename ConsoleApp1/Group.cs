namespace UniversityProject
{
    public class Group
    {
        public Group(string name)
        {
            Name = name;

            Students = new List<Student>();
        }

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
