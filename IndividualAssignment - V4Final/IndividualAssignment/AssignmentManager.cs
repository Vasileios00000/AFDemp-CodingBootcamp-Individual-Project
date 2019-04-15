using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    static class AssignmentManager
    {
        public static void AddAssignment()
        {

            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.Write("Please input the title of the assignment: ");
                    string title_input = Console.ReadLine();
                    Console.Write("Please input the description of the assignment: ");
                    string description_input = Console.ReadLine();
                    Console.Write("Please input the subission Date and Time of the Assignment (yyyy/mm/dd  hh:mm(hours)): ");
                    DateTime Date_input = Convert.ToDateTime(Console.ReadLine());
                   

                    Assignment A = new Assignment();
                    {
                        A.Title = title_input;
                        A.Description = description_input;
                        A.SubmissionDateAndTime = Date_input;                      
                    }
                    using (MyContext db = new MyContext())
                    {
                        db.Assignments.Add(A);
                        db.SaveChanges();
                    }
                    Console.Write("\nAssignmnet has been succesfully added\n");
                    loop = false;

                }
                catch (Exception)
                {

                    Console.WriteLine("\nASSIGNMENT HAS NOT ADDED\nPlease enter the inputs in the CORRECT FORM\n"); ;
                }
            }
        }


        public static void GetAllAssignments()
        {
            using (MyContext db = new MyContext())
            {
                List<Assignment> a = db.Assignments.OrderBy(x => x.Title).ToList();
                Assignment S = new Assignment();
                Console.WriteLine("ASSIGNMENTS LIST");
                S.PrintAssignments(a);

            }
        }

        public static void DeleteAssignment()
        {
            using (MyContext db = new MyContext())
            {
                List<Assignment> a = db.Assignments.OrderBy(x => x.Title).ToList();
                Assignment A = new Assignment();
                A.PrintAssignments(a);
                Console.Write("Please select the ID of the student you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Assignment A1 = db.Assignments.Find(id);
                Console.WriteLine($"The Assignment {A1.Title} has been removed");
                db.Assignments.Remove(A1);
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment()
        {
            using (MyContext db = new MyContext())
            {
                List<Assignment> a = db.Assignments.OrderBy(x => x.Title).ToList();
                Assignment A = new Assignment();
                A.PrintAssignments(a);
                Console.Write("Please select the ID of the assignment you want to uddate: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Assignment A1 = db.Assignments.Find(id);
                Console.WriteLine("Which attribute you want to update?");
                Console.WriteLine("1 - Title\n2 - Description\n3 - Date and Time of Submission");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter new title");
                        A1.Title = Console.ReadLine();

                        break;
                    case 2:
                        Console.WriteLine("Please enter new description");
                        A1.Description = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Please enter new Date and Time of Submission");
                        A1.SubmissionDateAndTime = Convert.ToDateTime(Console.ReadLine());
                        break;               
                }
                Console.WriteLine("Changes Saved");
                db.SaveChanges();

            }
        }


        


    }
}
