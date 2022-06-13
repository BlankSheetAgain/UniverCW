using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class University
    {
        public University()
        {
            Departments = new List<Department>();
        }

        public List<Department> Departments { get; set; }

        public override string ToString()
        {
            string result = String.Empty;

            foreach (var department in Departments)
            {

                result += department.Head.ToString();
                
                foreach (var group in department.Groups)
                {
                    result += group.ToString();
                    
                    foreach (var student in group.Students)
                    {
                        result += student.ToString();
                    }
                }
            }

            return result;
        }

        public List<Person> SelectByLastname (string lastname)
        {
            List<Person> result = new List<Person>();

            foreach (var department in Departments)
            {

                if (department.Head.Lastname == lastname)
                {
                    result.Add(department.Head);
                }

                foreach (var group in department.Groups)
                {
                    
                    if (group.Teacher.Lastname == lastname)
                    {
                        result.Add(group.Teacher);
                    }
                    
                    foreach (var student in group.Students)
                    {
                        
                        if (student.Lastname == lastname)
                        {
                            result.Add(student);
                        }
                    }
                }
            }

            return result;
        }
    }
}
