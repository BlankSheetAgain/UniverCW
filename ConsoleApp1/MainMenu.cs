using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public static class MainMenu
    {
        public static void Display(University university)
        {
            int choice;

            do
            {
                Console.WriteLine("Оберіть потрібний пукт меню\n" +
                    "1. Меню кафедр\n" +
                    "2. Меню груп\n" +
                    "3. Меню студентів\n" +
                    "4. Вивести усіх\n" +
                    "5. Вибірка по прізвищу\n");

                Console.Write(">");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();

                            DepartmentsMenu.Display(university);
                        }
                        break;

                    case 2:
                        {
                            Console.Clear();

                            GroupsMenu.Display(university);
                        }
                        break;

                    case 3:
                        {
                            Console.Clear();

                            GroupsMenu.Display(university);
                        }
                        break;

                    case 4:
                        {
                            Console.Clear();

                            Console.WriteLine(university.ToString());
                        }
                        break;

                    case 5:
                        {
                            Console.Clear();

                            Console.WriteLine("Введіть прізвище");

                            string lastname = Console.ReadLine();

                            if (university.SelectByLastname(lastname).Count > 0)
                            {

                                foreach (var person in university.SelectByLastname(lastname))
                                {
                                    Console.WriteLine(person.GetSubordinates(university));
                                };
                            }
                            else
                            {
                                Console.WriteLine("С таким прізвищем нікого не знайдено");
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

                Display(university);

            } while (Console.ReadKey().Key != ConsoleKey.End);
        }
    }
}
