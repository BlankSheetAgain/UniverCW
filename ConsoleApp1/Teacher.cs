using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class Teacher : Person
    {
        public override string GetSubordinates(University university)
        {
            string result = String.Empty;

            foreach (Department department in university.Departments)
            {

                for (int i = 0; i < department.Groups.Count; i++)
                {

                    if (department.Groups[i].Teacher == this)
                    {
                        result += $"--{this.Lastname} {this.Firstname} {this.Patronymic}\n";

                        foreach (var student in department.Groups[i].Students)
                        {
                            result += student.GetSubordinates(university) + "\n";
                        }
                    }
                }
            }
           
            return result;
        }
    }
}
