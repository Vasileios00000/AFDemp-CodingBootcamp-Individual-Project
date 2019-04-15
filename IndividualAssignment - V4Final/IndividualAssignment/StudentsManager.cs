using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    static class StudentsManager
    {

        public static void AddStudent()
        {

            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.Write("Please input the First Name of the Student: ");
                    string first_input = Console.ReadLine();
                    Console.Write("Please input the Last Name of the Student: ");
                    string last_input = Console.ReadLine();
                    Console.Write("Please input the Date Of Birth of the Student (yyyy/mm/dd): ");
                    DateTime Date_input = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Please input the tuition Fees of the Student: ");
                    int tuition_input = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please input the password for the Student account: ");
                    string password_input = Console.ReadLine();
                    double passwordHashed = Hashing.HashingMethod(password_input);


                    Student S = new Student();
                    {
                        S.FirstName = first_input;
                        S.LastName = last_input;
                        S.DateOfBirth = Date_input;
                        S.TuitionFees = tuition_input;
                        S.Password = passwordHashed;
                    }
                    using (MyContext db = new MyContext())
                    {
                        db.Students.Add(S);
                        db.SaveChanges();
                    }
                    Console.Write("\nStudent has been succesfully added\n");
                    loop = false;

                }
                catch (Exception)
                {

                    Console.WriteLine("\nSTUDENT HAS NOT ADDED\nPlease enter the inputs in the CORRECT FORM\n"); ;
                }
            }
        }


        public static void GetAllStudents()
        {
            using (MyContext db = new MyContext())
            {
                List<Student> a = db.Students.OrderBy(x => x.LastName).ToList();
                Student S = new Student();
                Console.WriteLine("STUDENTS LIST");
                S.PrintStudents(a);

            }
        }

        public static void DeleteStudent()
        {
            using (MyContext db = new MyContext())
            {
                List<Student> a = db.Students.OrderBy(x => x.LastName).ToList();
                Student S = new Student();
                S.PrintStudents(a);
                Console.Write("Please select the ID of the student you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Student S1 = db.Students.Find(id);
                Console.WriteLine($"The Student {S1.FirstName} {S1.LastName} has been removed");
                db.Students.Remove(S1);
                db.SaveChanges();
            }
        }

        public static void UpdateStudent()
        {
            using (MyContext db = new MyContext())
            {
                List<Student> a = db.Students.OrderBy(x => x.LastName).ToList();
                Student S = new Student();
                S.PrintStudents(a);
                Console.Write("Please select the ID of the student you want to uddate: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Student S1 = db.Students.Find(id);
                Console.WriteLine("Which attribute you want to update?");
                Console.WriteLine("1 - First Name\n2 - Last Name\n3 - Date Of Birth\n4 - Tuition Fees\n5 - Password");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter new name");
                        S1.FirstName = Console.ReadLine();

                        break;
                    case 2:
                        Console.WriteLine("Please enter new name");
                        S1.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Please enter new Date");
                        S1.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Please enter new Tuition Fees");
                        S1.TuitionFees = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Please enter new password");
                        string password = Console.ReadLine();
                        double HashedPassword = Hashing.HashingMethod(password);
                        S1.Password = HashedPassword;

                        break;

                }
                Console.WriteLine("Changes Saved");
                db.SaveChanges();

            }
        }


        public static void UNRelateStudentsCourses()
        {


            using (MyContext db = new MyContext())
            {

                      Console.WriteLine($"{"Stud ID",-10}  {"First Name",-10}  {"Last Name",15}  {"Course ID",-10}  {"Course Title",-15}");
                foreach (var x in db.Students)
                {
                    foreach (var y in x.Courses)
                    {
                        Console.WriteLine($"{x.StudentID,-10}  {x.FirstName,-10}  {x.LastName,15}  {y.CourseID,-10}  {y.Title,-15}");

                    }

                }
                Console.WriteLine("Select the Courses and the Students you want to UNrelate using their's IDs");
                Console.Write("Select a course id from the list: ");
                int id_C = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select a student id from the list: ");
                int id_S = Convert.ToInt32(Console.ReadLine());
                Course C1 = db.Courses.Find(id_C);
                Student S1 = db.Students.Find(id_S);
                S1.Courses.Remove(C1);
                db.SaveChanges();
                Console.WriteLine("UNrelation between the course and the student has been done\n");

            }
        }


        public static void RelateStudentsCourses()
        {


            using (MyContext db = new MyContext())
            {

                GetAllStudents();
                CourseManager.GetAllCourses();
                Console.WriteLine("Please relate the students and the courses using their ID's");
                Console.Write("Select a course id from the course list: ");
                int id_C = Convert.ToInt32(Console.ReadLine());
                Course C = new Course();
                Course C1 = db.Courses.Find(id_C);

                Student S = new Student();
                Console.Write("Select a Student id from the students list: ");
                int id_s = Convert.ToInt32(Console.ReadLine());
                Student S1 = db.Students.Find(id_s);
                S1.Courses.Add(C1);
                db.SaveChanges();
                Console.WriteLine("Input has been successfully submitted\n");

            }
        }





        public static void RelateStudentsAssignments()
        {
            using (MyContext db = new MyContext())
            {
                GetAllStudents();
                AssignmentManager.GetAllAssignments();
                Console.WriteLine("\nPLease relate the Students and the Assignments they have\n");
                Console.WriteLine("Select a student ID from the student's list: ");
                int id_s = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select a Assignment ID from the Assignments' list: ");
                int id_a = Convert.ToInt32(Console.ReadLine());


               // Assignment A = new Assignment();
                Assignment A1 = db.Assignments.Find(id_a);
               // Student S = new Student();
                Student S1 = db.Students.Find(id_s);
                StudentAssignment SA = new StudentAssignment();
                SA.Student = S1;
                SA.Assignment = A1;
                SA.StudentID = id_s;
                SA.AssignmentID = id_a;
                db.StudentAssignments.Add(SA);
                db.SaveChanges();
                Console.WriteLine("Input has been successfully submitted\n");
            }          
        }


        public static void UNRelateStudentsAssignments()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine($"{"StudentID",-10}  {"First Name",-10}  {"Last Name",15}  {"AssID",-10}  {"Title",-10}");

                foreach (var x in db.StudentAssignments)
                {

                    Console.WriteLine($"{x.StudentID,-10}  {db.Students.Find(x.StudentID).FirstName,-10}  {db.Students.Find(x.StudentID).LastName,15}  {x.AssignmentID,-10}  {db.Assignments.Find(x.AssignmentID).Title,-10}");

                }
              
                Console.WriteLine("\nPLease select the Students and the Assignments to UN-relate\n");
                Console.WriteLine("Select a student ID from the list: ");
                int id_s = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select an Assignment ID from the list: ");
                int id_a = Convert.ToInt32(Console.ReadLine());

                // StudentAssignment SA = new StudentAssignment();

                StudentAssignment SA = db.StudentAssignments.Where(x => x.StudentID == id_s).Where(y => y.AssignmentID == id_a).FirstOrDefault();
                db.StudentAssignments.Remove(SA);
                db.SaveChanges();
                Console.WriteLine("Remove has been successfully done\n");
            }
        }







    }
}
