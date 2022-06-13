using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class HeadOfDepartment : Person
    {
        public override string GetSubordinates(University university)
        {
            string result = String.Empty;

            for (int i = 0; i < university.Departments.Count; i++)
            {

                if (university.Departments[i].Head == this)
                {

                    result += $"-{this.Lastname} {this.Firstname} {this.Patronymic}\n";
                    
                    foreach (var groups in university.Departments[i].Groups)
                    {
                        result += groups.Teacher.GetSubordinates(university) + "\n";
                    }
                }
            }

            return result;
        }
    }
}
