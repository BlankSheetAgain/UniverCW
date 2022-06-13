namespace UniversityProject
{
    public class Group
    {
        public Group(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
