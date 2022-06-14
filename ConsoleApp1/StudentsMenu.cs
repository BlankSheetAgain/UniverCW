using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class StudentsMenu
    {

        public static void Display(University university)
        {
            if (university.Departments.Count == 0)
            {
                Console.WriteLine("Кафедр ще не було додано");
            }

            else
            {
                Console.WriteLine("Оберіть кафедру");

                for (int i = 0; i < university.Departments.Count; i++)
                {
                    Console.WriteLine(i + " " + university.Departments[i].Name);
                }
                Console.Write(">");

                int depchoice = int.Parse(Console.ReadLine());


                if (university.Departments.Count > depchoice && university.Departments[depchoice] != null)
                {

                    DisplayGroups(university, depchoice);

                }
                else
                {

                    Console.WriteLine("Такої кафедри не існує");
                }
            }
        }


        public static void DisplayGroups(University university, int depchoice)
        {
            if (university.Departments[depchoice].Groups.Count == 0)
            {
                Console.WriteLine("Груп на цій кафедрі ще не було додано");
            }

            else
            {
                Console.WriteLine("Оберіть групу");

                for (int i = 0; i < university.Departments[depchoice].Groups.Count; i++)
                {
                    Console.WriteLine(i + " " + university.Departments[depchoice].Groups[i].Name);
                }
                Console.Write(">");

                int groupchoice = int.Parse(Console.ReadLine());


                if (university.Departments[depchoice].Groups.Count > groupchoice && university.Departments[depchoice].Groups[groupchoice] != null)
                {

                    DisplayMenu(university, depchoice, groupchoice);

                }
                else
                {

                    Console.WriteLine("Такої групи не існує");
                }
            }
        }

        public static void DisplayMenu(University university, int depchoice, int groupchoice)
        {
            int choice;

            do
            {
                Console.WriteLine("Оберіть потрібний пункт меню\n" +
                    "1. Додати студента\n" +
                    "2. Видалити студента\n" +
                    "3. Відобразити всіх студентів\n" +
                    "4. Повернутися у попереднє меню\n");

                Console.Write(">");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("ВВедіть прізвище студента");

                            string lastname = Console.ReadLine();

                            Console.WriteLine("ВВедіть ім'я студента");

                            string firstname = Console.ReadLine();

                            Console.WriteLine("ВВедіть по-батькові студента");

                            string patronymic = Console.ReadLine();

                            Console.WriteLine("ВВедіть дату народження у форматі день/місяць/рік");

                            DateOnly birthday = DateOnly.Parse(Console.ReadLine());

                            university.Departments[depchoice].Groups[groupchoice].Students.Add(new Student { Lastname = lastname, Firstname = firstname, Patronymic = patronymic, Birthday = birthday });
                        }
                        break;

                    case 2:
                        {
                            Console.Clear();

                            if (university.Departments[depchoice].Groups[groupchoice].Students.Count == 0)
                            {
                                Console.WriteLine("Студентів в даній групі ще не було додано");
                            }

                            else
                            {
                                for (int i = 0; i < university.Departments[depchoice].Groups[groupchoice].Students.Count; i++)
                                {
                                    Console.WriteLine(i + " " + university.Departments[depchoice].Groups[groupchoice].Students[i].Lastname);
                                }
                                Console.Write(">");

                                int choice2 = int.Parse(Console.ReadLine());

                                if (university.Departments[depchoice].Groups[groupchoice].Students.Count > choice2 && university.Departments[depchoice].Groups[groupchoice].Students[choice2] != null)
                                {
                                    university.Departments[depchoice].Groups[groupchoice].Students.RemoveAt(choice2);

                                    Console.WriteLine("Студента було успішно видалено");
                                }
                                else
                                {
                                    Console.WriteLine("Такого студента не знайдено");
                                }
;
                            }
                        }
                        break;

                        case 3:
                        {
                            Console.Clear();

                            if (university.Departments[depchoice].Groups[groupchoice].Students.Count == 0)
                            {
                                Console.WriteLine("Cтудентів у цій групі ще не було додано");
                            }

                            else
                            {
                                foreach (var student in university.Departments[depchoice].Groups[groupchoice].Students)
                                {
                                    Console.WriteLine(student.Lastname);
                                }
                            }
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Неправильний вибір, спробуйте ще раз");
                        }
                        break;
                }
                Console.WriteLine("Для продовження натисніть будь яку клавішу");

                Console.ReadKey();

                Console.Clear();

                DisplayMenu(university, depchoice, groupchoice);

            } while (Console.ReadKey().Key != ConsoleKey.End);
        }
    }
}
