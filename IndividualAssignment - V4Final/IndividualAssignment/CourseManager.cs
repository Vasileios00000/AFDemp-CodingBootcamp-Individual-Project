using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    static class CourseManager
    {
        public static void AddCourse()
        {
       
                    Console.Write("Please input the title of the Course: ");
                    string title_input = Console.ReadLine();
                    Console.Write("Please input the Stream of the Course (j for Java, c for C#): ");
                    string stream_input = Console.ReadLine();
                    Console.Write("Please input the type Of the course (f for Full-TIme, p for Part-Time): ");
                    string type_input = Console.ReadLine();
                    Console.Write("Please input the Start Date of the course(yyyy/mm/dd): ");
                    DateTime startdate_input = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Please input the End Date of the course(yyyy/mm/dd): ");
                    DateTime enddate_input = Convert.ToDateTime(Console.ReadLine());


                    Course C = new Course();
                    {
                         C.Title = title_input;
                         if (stream_input == "j")
                         {
                         C.Stream = true;

                         }
                        else
                         {
                         C.Stream = false;
                         }
                        if (type_input == "f")
                        {
                            C.Type = true;

                        }
                        else
                        {
                             C.Type = false;
                        }


                         C.StartTime = startdate_input;
                         C.EndTime = enddate_input;        
                    }
                    using (MyContext db = new MyContext())
                    {
                        db.Courses.Add(C);
                        db.SaveChanges();
                    }
                    Console.Write("\nCourse has been succesfully added\n");
                 

             
        }

        public static void GetAllCourses()
        {
            using (MyContext db = new MyContext())
            {
                List<Course> a = db.Courses.OrderBy(x => x.Title).ToList();
                Course C = new Course();
                Console.WriteLine("COURSES LIST");
                C.PrintCourses(a);

            }
        }

        public static void DeleteCourse()
        {
            using (MyContext db = new MyContext())
            {
                List<Course> a = db.Courses.OrderBy(x => x.Title).ToList();
                Course C = new Course();
                C.PrintCourses(a);
                Console.Write("Please select the ID of the course you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Course C1 = db.Courses.Find(id);
                Console.WriteLine($"The Course {C1.Title} has been removed");
                db.Courses.Remove(C1);
                db.SaveChanges();
            }
        }

        public static void UpdateCourse()
        {
            using (MyContext db = new MyContext())
            {
                List<Course> a = db.Courses.OrderBy(x => x.Title).ToList();
                Course C = new Course();
                C.PrintCourses(a);
                Console.Write("Please select the ID of the course you want to uddate: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Course C1 = db.Courses.Find(id);
                Console.WriteLine("Which attribute you want to update?");
                Console.WriteLine("1 - Title\n2 - Stream (j for Java C for C#)\n3 - Type (f for full-time p for part-time)\n4 - Start Date of the Course(yyy/mm/dd)\n5 - End Date of the Course(yyy/mm/dd)");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter new title");
                        C1.Title = Console.ReadLine();

                        break;
                    case 2:
                        Console.WriteLine("Please enter new Stream (j for Java C for C#)");
                        string stream_input= Console.ReadLine();
                        if (stream_input=="j")
                        {
                            C1.Stream = true;
                        }
                        else
                        {
                            C1.Stream = false;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Please enter new Type (f for full-time P for part-time)");
                        string type_input = Console.ReadLine();
                        if (type_input == "f")
                        {
                            C1.Type = true;
                        }
                        else
                        {
                            C1.Type = false;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter new Start Date(yyyy/mm/dd)");
                        C1.StartTime = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Please enter new End Date(yyyy/mm/dd)");
                        C1.EndTime = Convert.ToDateTime(Console.ReadLine());
                        break;
                }
                Console.WriteLine("Changes Saved");
                db.SaveChanges();         
            }
        }


        public static void RelateAssignmentsToCourses()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine("Please add Assignment to the course using the ID's from the lists");
                GetAllCourses();
                AssignmentManager.GetAllAssignments();
                Console.Write("Select the Course id from the list you want to add an assignment: ");
                int id_c = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select the Assignment id from the list you want to add to the course: ");
                int id_a = Convert.ToInt32(Console.ReadLine());                          
                Course C1 = db.Courses.Find(id_c);
                Assignment A1 =db.Assignments.Find(id_a);
                C1.Assignments.Add(A1);
                db.SaveChanges();
                Console.WriteLine("\nAssignment successfully submitted to the course");
            }

        }

        public static void UNRelateAssignmentsToCourses()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine("Please select Assignment and course using the ID's from the list to UN-relate\n");
                Console.WriteLine($"{"Assignment ID",-15}  {"Ass. Title",-10}  {"Course ID",-15}  {"Course Title",-15}");
                foreach (var x in db.Courses)
                {
                    foreach (var y in x.Assignments)
                    {
                        Console.WriteLine($"{y.AssignmentID,-15}  {y.Title,-10}  {x.CourseID,-15}  {x.Title,-15}");
                    }
                }
                Console.Write("Select the Assignment id from the list: ");
                int id_a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select the Course id from the list: ");
                int id_c = Convert.ToInt32(Console.ReadLine());
                Assignment A1 = db.Assignments.Find(id_a);
                Course C1 = db.Courses.Find(id_c);
                C1.Assignments.Remove(A1);             
                db.SaveChanges();
                Console.WriteLine("\nAssignment successfully removed from the course");
            }

        }
















    }
}
