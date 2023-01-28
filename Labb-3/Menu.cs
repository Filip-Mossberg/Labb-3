using Labb_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3
{
    internal class Menu : DbContext
    {
        SchoolDbContext context = new SchoolDbContext();
        
        public void MenuList()
        {
            Console.Clear();
            Console.WriteLine("\tWelcome to the School!\n" +
                "" +
                "\n\t--Menu--" +
                "\n\t1. Hämta alla elever" +
                "\n\t2. Hämta alla elever i en viss klass" +
                "\n\t3. Lägg till ny personal");

            string Input = Console.ReadLine();
            int.TryParse(Input, out int Pick);

            switch (Pick)
            {
                case 1:
                    GetAllUsers();
                    break;
                case 2:
                    StudentsInAClass();
                    break;
                case 3:
                    NewPersonal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Error!");
                    Console.ReadLine();
                    MenuList();
                    break;
            }
        }
        public (int,int) SettingsForGetAllUsers()
        {
            Console.WriteLine("\tHur ska eleverna sorteras?" +
               "\n\t1. Förnamn först" +
               "\n\t2. Efternamn först");

            string Input1 = Console.ReadLine();
            int.TryParse(Input1, out int SortByName);

            Console.WriteLine("\tStigande eller fallande ordning" +
                "\n\t1. Stigande" +
                "\n\t2. Fallande");

            string Input2 = Console.ReadLine();
            int.TryParse(Input2, out int SortByDisplay);

            return (SortByName, SortByDisplay);
        }
        public void GetAllUsers()
        {
            (int SortByName, int SortByDisplay) = SettingsForGetAllUsers();

            if (SortByName == 1)
            {
                if (SortByDisplay == 1)
                {
                    var FirstNameAccending = context.Students.OrderBy(x => x.FirstName);
                    Console.Clear();
                    foreach (var item in FirstNameAccending)
                    {
                        Console.WriteLine($"Person ID {item.StudentId} {item.FirstName} {item.LastName}");
                    }
                    Console.ReadLine();
                }
                else if (SortByDisplay == 2)
                {
                    var FirstNameDecending = context.Students.OrderByDescending(x => x.FirstName);
                    Console.Clear();
                    foreach (var item in FirstNameDecending)
                    {
                        Console.WriteLine($"Person ID {item.StudentId} {item.FirstName} {item.LastName}");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error! Please try again.");
                    Console.ReadLine();
                    GetAllUsers();
                }
            }
            else if (SortByName == 2)
            {
                if (SortByDisplay == 1)
                {
                    var LastNameAccending = context.Students.OrderBy(x => x.LastName);
                    Console.Clear();
                    foreach (var item in LastNameAccending)
                    {
                        Console.WriteLine($"Person ID {item.StudentId} {item.FirstName} {item.LastName}");
                    }
                    Console.ReadLine();
                }
                else if (SortByDisplay == 2)
                {
                    var LastNameDecending = context.Students.OrderByDescending(x => x.LastName);
                    Console.Clear();
                    foreach (var item in LastNameDecending)
                    {
                        Console.WriteLine($"Person ID {item.StudentId} {item.FirstName} {item.LastName}");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error! Please try again.");
                    Console.ReadLine();
                    GetAllUsers();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error! Please try again.");
                Console.ReadLine();
                GetAllUsers();
            }
            MenuList();
        }
        public void StudentsInAClass()
        {
            var AllClasses = context.Classes;
            Console.WriteLine("\n\tPick a class:\n");

            foreach (var item in AllClasses)
            {
                Console.WriteLine($"\t{item.ClassName}");
            }

            string ClassName = Console.ReadLine();

            var SpecificClass = context.Classes.Where(x => x.ClassName == ClassName).FirstOrDefault();
            var UsersInClass = context.Students.Where(x => x.ClassId == SpecificClass.ClassId);
            Console.Clear();
            Console.WriteLine($"\tStudens in class {ClassName}");
            foreach (var item in UsersInClass)
            {
                Console.WriteLine($"\tPerson {item.StudentId} {item.FirstName} {item.LastName}");
            }
            Console.ReadLine();
            MenuList();
        }
        public void NewPersonal()
        {
            Console.Clear();
            Console.Write("\tFirst name: ");
            string Name = Console.ReadLine();

            Console.Write("\tLast name: ");
            string LastName = Console.ReadLine();

            Console.Write("\tEmail: ");
            string Email = Console.ReadLine();

            Personal p1 = new Personal()
            {
                FName = Name,
                LName = LastName,
                Email = Email
            };

            context.Personals.Add(p1);
            context.SaveChanges();

            Console.Clear();
            Console.WriteLine("\tSuccess!");
            Console.ReadLine();
            MenuList();
        }
            
    }
}
