using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public class GroupsMenu
    {
        public static void Display(University university)
        {
            int choice;

            do
            {
                Console.WriteLine("Оберіть потрібний пункт меню\n" +
                    "1. Додати групу\n" +
                    "2. Видалити групу\n" +
                    "3. Відобразити всі групи\n" +
                    "4. Повернутися у попереднє меню\n");

                Console.Write(">");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();

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

                                int choice2 = int.Parse(Console.ReadLine());

                                if (university.Departments[choice2] == null || university.Departments.Count < choice2)
                                {

                                    Console.WriteLine("Такої кафедри не існує");

                                }

                                else
                                {
                                    Console.WriteLine("Введіть назву групи");

                                    string name = Console.ReadLine();

                                    university.Departments[choice2].Groups.Add(new Group(name));
                                    
                                }

                                Console.WriteLine("Кафедру було успішно видалено");
                            }

                        }
                        break;

                    case 2:
                        {
                            Console.Clear();

                            if (university.Departments.Count == 0)
                            {
                                Console.WriteLine("Кафедр ще не було додано");

                            }
                            else
                            {
                                for (int i = 0; i < university.Departments.Count; i++)
                                {
                                    Console.WriteLine(i + " " + university.Departments[i].Name);
                                }
                                Console.Write(">");

                                int choice2 = int.Parse(Console.ReadLine());

                                if (university.Departments[choice2] == null || university.Departments.Count < choice2)
                                {

                                    Console.WriteLine("Такої кафедри не існує");

                                    return;
                                }

                                university.Departments.RemoveAt(choice2);

                                Console.WriteLine("Кафедру було успішно видалено");
                            }
                        }
                        break;

                    case 3:
                        {
                            Console.Clear();

                            foreach (var department in university.Departments)
                            {
                                Console.WriteLine(department.Name + "\n");
                            }
                        }
                        break;

                    case 4:
                        {
                            Console.Clear();

                            MainMenu.Display(university);
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

                DepartmentsMenu.Display(university);

            } while (Console.ReadKey().Key != ConsoleKey.End);
        }
    }
}
