namespace UniversityProject
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public HeadOfDepartment Head { get; set; }

        public List<Group> Groups { get; set; }
    }
}
