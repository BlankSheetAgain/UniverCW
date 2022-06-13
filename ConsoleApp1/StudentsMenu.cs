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
                    if (university.Departments[depchoice].Groups.Count == 0)
                    {
                        Console.WriteLine("Груп на цій кафедрі ще не було додано");
                    }

                    else
                    {
                        Console.WriteLine("Оберіть групу");

                        for (int i = 0; i < university.Departments[depchoice].Groups.Count; i++)
                        {
                            Console.WriteLine(i + " " + university.Departments[i].Name);
                        }
                        Console.Write(">");

                        int groupchoice = int.Parse(Console.ReadLine());

                        if (university.Departments[depchoice].Groups.Count>groupchoice&&university.Departments[depchoice].Groups[groupchoice]!=null)
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
                                            Console.WriteLine("Введіть дані студентів");



                                            university.Departments[depchoice].Groups[groupchoice].Students.Add(new Student { Firstname="Marko", Lastname="Polo", Patronymic="Paul", Birthday=new DateOnly(2022, 10, 12)});
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
                }
            }
        }
    }
