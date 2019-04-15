using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;
using System.Data.SqlClient;

namespace IndividualAssignment.Users
{
    public class UserStudent
    {
        public static void MenouStudent(int stu_id)
        {
            
                using (MyContext db = new MyContext())
                {                  
                    Console.WriteLine($"\nHello {db.Students.Find(stu_id).FirstName},\n");
                while (1 == 1)
                {
                    try
                    {

                    
                        Console.WriteLine("");                   
                        Console.WriteLine("1 - Enroll in a Course");
                        Console.WriteLine("2 - Submit an Assignment");
                        Console.WriteLine("3 - See your Courses");
                        Console.WriteLine("4 - See your Daily Courses");
                        Console.WriteLine("5 - See the dates of Submission of the assignments per course");
                        Console.WriteLine("6 - Exit from the programme");
                        Console.WriteLine("Please select one of the options: ");
                        int user_chioce = Convert.ToInt32(Console.ReadLine());

                        switch (user_chioce)
                        {
                            case 1:
                                EnrollinCourse(stu_id);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 2:
                                SubmitAssignment(stu_id);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 3:
                                SeeCourses(stu_id);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 4:
                                SeeDailyCourses(stu_id);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 5:
                                SeeSDatesOfAssignmentperCourse(stu_id);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 6:
                                Environment.Exit(0);
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Wrong Input");
                    }


                }
            }

        }








        public static void EnrollinCourse(int id)
        {
            Console.WriteLine("Pease select a course by ID from the following list in which you want to enroll/n");
            CourseManager.GetAllCourses();
            Console.Write("\nSelect course id you want to enroll: ");
            int id_C = Convert.ToInt32(Console.ReadLine());
           
            using (MyContext db = new MyContext())
            {
                Course C1 = new Course();
                Student SS = new Student();
                C1 = db.Courses.Find(id_C);
                
                int userID = id;
                SS = db.Students.Find(userID);
                SS.Courses.Add(C1);
                db.SaveChanges();
                Console.WriteLine($"{SS.FirstName} {SS.LastName} You have successfully enrolled to the Course: {C1.Title}");
            }
        }

        public static void SeeCourses(int id)
        {
            using (MyContext db = new MyContext()) {

                Student S1 = db.Students.Find(id);

                
                Course C = new Course();

                C.PrintCourses(S1.Courses.ToList());
                           
            }

        }

        public static void SeeDailyCourses(int id)
        {
            using (MyContext db = new MyContext())
            {

                Student S1 = db.Students.Find(id);

                Console.Write("Please input the a Date to see which Courses you have(yyyy/mm/dd): ");
                DateTime Date_input = Convert.ToDateTime(Console.ReadLine());
                Course C = new Course();

                Console.WriteLine($"{"ID",-3}  {"Title",-11}  {"Stream",-11}  {"Type",-10}  {"StartTime",-15}  {"EndTime",-15}");
                foreach (var x in S1.Courses.ToList())
                {
                    if(x.StartTime< Date_input && x.EndTime > Date_input)
                    {
                        string Str;
                        string Typ;
                        if (x.Stream)
                        {
                            Str = "Java";
                        }
                        else
                        {
                            Str = "C#";
                        }
                        if (x.Type)
                        {
                            Typ = "Full-Time";
                        }
                        else
                        {
                            Typ = "Part-Time";
                        }
                        Console.WriteLine($"{x.CourseID,-3}  {x.Title,-11}  {Str,-11}  {Typ,-10}  {x.StartTime.Date.ToString("d"),-15}  {x.EndTime.Date.ToString("d"),-15}  ");


                    }

                }


            }

        }














        public static void SeeSDatesOfAssignmentperCourse(int id)
        {
            using(MyContext db = new MyContext())
            {
                Student S1 = new Student();
                S1 =db.Students.Find(id);
                StudentAssignment SA = new StudentAssignment();
                List<StudentAssignment > SAA = db.StudentAssignments.Where(x => x.StudentID == id).ToList();

                Console.WriteLine($"{"Course",-11}  {"Assignment",-11}  {"Submission Date and Time",-30}  {"Submitted",-10}\n");
                foreach (var x in S1.Courses)
                {
                    foreach (var y in x.Assignments)
                    {

                        string submitted = "No";
                        foreach (var z in SAA)
                        {
                            if (z.AssignmentID == y.AssignmentID && z.SubmittedYesorNo=="Yes")
                            {
                                submitted = "Yes";
                            }
                        }
                                                                                                                                                                  
                        Console.WriteLine($"{x.Title,-11}  {y.Title,-11}  {y.SubmissionDateAndTime,-30}  {submitted,-10}");
                    }
                }
            }
        }

        public static void SubmitAssignment(int id)
        {
            using (MyContext db = new MyContext())
            {

                StudentAssignment SA = new StudentAssignment();
                


                List<StudentAssignment> ASD = db.StudentAssignments.Where(x => x.StudentID == id).ToList();

                
                Console.WriteLine($"{"ID",-3}  {"Assignment",-11}  {"Description",-17}  {"Submission Date and Time",-25}  {"Submitted",-10}\n");

                foreach (var x in ASD)
                {                 
                        Console.WriteLine($"{x.AssignmentID,-3}  {x.Assignment.Title,-11}  {x.Assignment.Description,-17}  {x.Assignment.SubmissionDateAndTime,-25}  {x.SubmittedYesorNo,-10}");                  
                }

                Console.WriteLine("These are your Assignments\nWhich of these do you want to submit(select ID): ");
                int ass_id = Convert.ToInt32(Console.ReadLine());


                StudentAssignment SA1 = db.StudentAssignments.Where(x => x.StudentID == id).Where(x => x.AssignmentID == ass_id).FirstOrDefault();

                SA1.SubmittedYesorNo = "Yes";        
                db.SaveChanges();           
                Console.WriteLine("\nAssignment successfully Submited");
            }
        }

        //public static void SeeDailyCoursesSchedue(int id)
        //{
        //    using (MyContext db = new MyContext())
        //    {

        //        Student S1 = db.Students.Find(id);

        //        foreach (var item in collection)
        //        {

        //        }


        //        Course C = new Course();

        //        C.PrintCourses(S1.Courses.ToList());

        //    }

        //}






    }


    }
