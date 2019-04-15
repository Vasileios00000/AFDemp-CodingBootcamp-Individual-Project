using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment.Users
{
   
    public static class UserTrainer
    {

        public static void MenouTrainer(int tr_id)
        {

            using (MyContext db = new MyContext())
            {
                Console.WriteLine($"\nHello {db.Trainers.Find(tr_id).FirstName},\n");
                while (1 == 1)
                {
                    try
                    {





                        {
                            Console.WriteLine("");
                            Console.WriteLine("1 - View all the courses you are teaching");
                            Console.WriteLine("2 - View all the Students per Course");
                            Console.WriteLine("3 - View all the Assignments per Student per Course");
                            Console.WriteLine("4 - Mark all the Assignments per Student per Course");
                            Console.WriteLine("5 - Exit from the programme");
                            Console.WriteLine("Please select one of the options: ");
                            int user_chioce = Convert.ToInt32(Console.ReadLine());

                            switch (user_chioce)
                            {
                                case 1:
                                    ViewCourses(tr_id);
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    ViewStudentsperCourse(tr_id);
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    ViewAssignmentperStudentperCourse(tr_id);
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    MarkAssignmentperStudentperCourse(tr_id);
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Wrong Input");
                    }
                }
            }
        }


                    




        public static void ViewCourses(int id)
        {
            using (MyContext db = new MyContext())
            {

                Trainer T1 = db.Trainers.Find(id);


                Course C = new Course();

                C.PrintCourses(T1.Courses.ToList());

            }

        }

        public static void ViewStudentsperCourse(int id)
        {
            using (MyContext db = new MyContext())
            {

                Trainer T1 = db.Trainers.Find(id);

                Console.WriteLine($"{"Course ID",-10}  {"Title",-11}  {"Start Date",-15}  {"Student ID",-10}  {"First Name",-15}  {"Last Name",-15}");
                foreach (var x in T1.Courses)
                {
                    foreach (var y in x.Students)
                    {
                        Console.WriteLine($"{x.CourseID,-10}  {x.Title,-11}  {x.StartTime.Date.ToString("d"),-15}  {y.StudentID,-10}  {y.FirstName,-15}  {y.LastName,-15}");


                    }

                }


            }

        }

        public static void ViewAssignmentperStudentperCourse(int id)
        {
            using (MyContext db = new MyContext())
            {

                Trainer T1 = db.Trainers.Find(id);


                Course C = new Course();

                Console.WriteLine($"{"Ass. ID",-9}  {"Assignment Title",-20}  {"Mark",-6}  {"Course Title",-15}  {"Stu. ID",-9}  {"First Name",-10}  {"Last Name",-10}");

                foreach (var x in T1.Courses)
                {
                    foreach (var y in x.Assignments)
                    {
                        foreach (var z in y.StudentAssignments)
                        {

                            Console.WriteLine($"{y.AssignmentID,-9}  {y.Title,-20}  {z.Mark,-6}  {x.Title,-15}  {db.Students.Find(z.StudentID).StudentID,-9}  {db.Students.Find(z.StudentID).FirstName,-10}  {db.Students.Find(z.StudentID).LastName,-10}");

                        }

                    }

                }




            }

        }

        public static void MarkAssignmentperStudentperCourse(int id)
        {
            ViewAssignmentperStudentperCourse(id);

            using (MyContext db = new MyContext())
            {
                

                Console.WriteLine("Select the ID of the Assignment you want to mark: ");
                int ass_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select the ID of the Student you want to mark: ");
                int stu_id = Convert.ToInt32(Console.ReadLine());
                StudentAssignment a = db.StudentAssignments.Where(x => (x.StudentID == stu_id && x.AssignmentID == ass_id && x.SubmittedYesorNo=="Yes")).FirstOrDefault();              
                Console.WriteLine("!!!Watch out in order to Mark an assignment, it must first submitted by the Student");
                Console.WriteLine("otherwise your mark will not be saved");
                Console.WriteLine("Please enter a Mark for that Assignment(0-100): ");
                a.Mark = Convert.ToInt32(Console.ReadLine());
                db.SaveChanges();
                Console.WriteLine("Mark has been successfully Submitted");

            }
        }



    }

}   

