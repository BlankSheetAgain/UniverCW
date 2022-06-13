﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject
{
    public static class DepartmentsMenu
    {
        public static void Display(University university)
        {
            int choice;

            do
            {
                Console.WriteLine("Оберіть потрібний пункт меню\n" +
                    "1. Додати кафедру\n" +
                    "2. Видалити кафедру\n" +
                    "3. Відобразити всі кафедри\n" +
                    "4. Повернутися у попереднє меню\n");

                Console.Write(">");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();

                            Console.WriteLine("Введіть назву кафедри");

                            string name = Console.ReadLine();

                            university.Departments.Add(new(name));

                            university.Departments[0].Head = new HeadOfDepartment { Lastname = "Zola", Firstname = "Hola", Patronymic = "Yula", Birthday = new DateOnly(2022, 10, 10) };

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

                                if (university.Departments.Count > choice2 && university.Departments[choice2] != null)
                                {
                                    university.Departments.RemoveAt(choice2);

                                    Console.WriteLine("Кафедру було успішно видалено");

                                }

                                else
                                {
                                    Console.WriteLine("Такої кафедри не існує");
                                }

                                
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
