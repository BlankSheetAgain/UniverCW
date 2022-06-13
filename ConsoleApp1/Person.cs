using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public abstract class Person
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Patronymic { get; set; }

        public DateOnly Birthday { get; set; }

        public abstract string GetSubordinates(University university);
    }
}
