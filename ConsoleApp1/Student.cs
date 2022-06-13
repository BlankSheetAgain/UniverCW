using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class Student : Person
    {
        public override string GetSubordinates(University university)
        {
            return $"---{this.Lastname} {this.Firstname} {this.Patronymic}";
        }
    }
}
