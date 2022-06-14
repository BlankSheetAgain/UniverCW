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

                    DisplayMenu(university, depchoice);
                   
                }
                else
                {

                    Console.WriteLine("Такої кафедри не існує");
                }
            }
         }

        public static void DisplayMenu(University university, int depchoice)
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
                            Console.WriteLine("Введіть назву групи");

                            string name = Console.ReadLine();

                            university.Departments[depchoice].Groups.Add(new Group(name));

                            university.Departments[0].Groups[0].Teacher = new Teacher { Lastname = "Lola", Firstname = "Hola", Patronymic = "Yula", Birthday = new DateOnly(2022, 10, 10) };
                            university.Departments[depchoice].Groups[0].Students.Add(new Student { Firstname = "Marhhko", Lastname = "Pol65o", Patronymic = "Paul", Birthday = new DateOnly(2022, 10, 12) });
                            university.Departments[depchoice].Groups[0].Students.Add(new Student { Firstname = "Markohh", Lastname = "Polr6o", Patronymic = "Paul", Birthday = new DateOnly(2022, 10, 12) });

                        }
                        break;

                    case 2:
                        {
                            Console.Clear();

                            if (university.Departments[depchoice].Groups.Count == 0)
                            {
                                Console.WriteLine("Груп на даній кафедрі ще не було додано");
                            }

                            else
                            {
                                for (int i = 0; i < university.Departments[depchoice].Groups.Count; i++)
                                {
                                    Console.WriteLine(i + " " + university.Departments[depchoice].Groups[i].Name);
                                }
                                Console.Write(">");

                                int choice2 = int.Parse(Console.ReadLine());

                                if (university.Departments[depchoice].Groups[choice2] == null || university.Departments[depchoice].Groups.Count < choice2)
                                {

                                    Console.WriteLine("Такої групи не існує");

                                }

                                university.Departments[depchoice].Groups.RemoveAt(choice2);

                                Console.WriteLine("групу було успішно видалено");
                            }
                        }
                        break;

                    case 4:
                        {
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

                DisplayMenu(university, depchoice);

            } while (Console.ReadKey().Key != ConsoleKey.End);
        }
    }
}
