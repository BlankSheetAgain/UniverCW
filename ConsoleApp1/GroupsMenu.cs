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
                    "4. Повернутися у попереднє меню\n"+
                    "5. Додати викладача\n" +
                    "6. Видалити викладача\n" +
                    "7. Вивести викладача\n"
                    );

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

                    case 3:
                        {
                            Console.Clear();

                            if (university.Departments[depchoice].Groups.Count == 0)
                            {
                                Console.WriteLine("Груп на даній кафедрі ще не було додано");
                            }

                            else
                            {
                                foreach (var group in university.Departments[depchoice].Groups)
                                {
                                    Console.WriteLine(group.Name);
                                }
                            }
                        }break;

                    case 4:
                        {
                            MainMenu.Display(university);
                        }
                        break;

                    case 5:
                        {
                            if (university.Departments[depchoice].Groups[choice].Teacher is null)
                            {
                                Console.WriteLine("ВВедіть прізвище викладача");

                                string lastname = Console.ReadLine();

                                Console.WriteLine("ВВедіть ім'я викладача");

                                string firstname = Console.ReadLine();

                                Console.WriteLine("ВВедіть по-батькові викладача");

                                string patronymic = Console.ReadLine();

                                Console.WriteLine("ВВедіть дату народження у форматі день/місяць/рік");

                                DateOnly birthday = DateOnly.Parse(Console.ReadLine());

                                university.Departments[depchoice].Groups[choice].Teacher = new Teacher { Lastname = lastname, Firstname = firstname, Patronymic = patronymic, Birthday = birthday };
                            }

                            else
                            {
                                Console.WriteLine("У цієї групи вже є викладач");
                            }
                        }
                        break;

                    case 6:
                        {
                            if (university.Departments[depchoice].Groups[choice].Teacher is null)
                            {
                                Console.WriteLine("У цієї групи немає викладача");
                            }

                            else
                            {
                                university.Departments[depchoice].Groups[choice].Teacher = null;

                                Console.WriteLine("Викладача успішно видалено");
                            }
                        }
                        break;

                    case 7:
                        {
                            if (university.Departments[depchoice].Groups[choice].Teacher is null)
                            {
                                Console.WriteLine("У цієї групи немає викладача");
                            }

                            else
                            {
                                Console.WriteLine(university.Departments[depchoice].Groups[choice].Teacher.Lastname);
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

                DisplayMenu(university, depchoice);

            } while (Console.ReadKey().Key != ConsoleKey.End);
        }
    }
}
