namespace UniversityProject
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;

            Groups = new List<Group>();
        }

        public string Name { get; set; }

        public HeadOfDepartment Head { get; set; }

        public List<Group> Groups { get; set; }
    }
}
