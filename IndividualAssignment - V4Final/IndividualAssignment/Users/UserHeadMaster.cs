using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment.Users
{
    class UserHeadMaster
    {
        public static void MenouHeadMaster(int hm_id)
        {


            using (MyContext db = new MyContext())
            {
                Console.WriteLine($"\nHello {db.HeadMasters.Find(hm_id).FirstName},\n");
                while (1 == 1)
                {
                    try
                    {

                    

                        Console.WriteLine("");
                        Console.WriteLine("1 - Add a Student");
                        Console.WriteLine("2 - Update a Student");
                        Console.WriteLine("3 - Delete a Student");
                        Console.WriteLine("4 - Add a Trainer");
                        Console.WriteLine("5 - Update a Trainer");
                        Console.WriteLine("6 - Delete a Trainer");
                        Console.WriteLine("7 - Add a Course");
                        Console.WriteLine("8 - Update a Course");
                        Console.WriteLine("9 - Delete a Course");
                        Console.WriteLine("10 - Add an Assignment");
                        Console.WriteLine("11 - Update an Assignment");
                        Console.WriteLine("12 - Delete an Assignment");
                        Console.WriteLine("13 - Add a Head-Master");
                        Console.WriteLine("14 - Delete a Head-Master");
                        Console.WriteLine("15 - Relate Courses and Students(students per courses)");
                        Console.WriteLine("16 - UN-Relate Courses and Students(students per courses)");
                        Console.WriteLine("17 - Relate Trainers and Courses(Trainers per courses)");
                        Console.WriteLine("18 - UN-Relate Trainers and Courses(Trainers per courses)");
                        Console.WriteLine("19 - Relate Assignments and Courses(Assignments per courses)");
                        Console.WriteLine("20 - UN-Relate Assignments and Courses(Assignments per courses)");
                        Console.WriteLine("21 - Relate Assignments and Students(Assignments per Students)");
                        Console.WriteLine("22 - UN-Relate Assignments and Students(Assignments per Students)");



                        Console.WriteLine("23 - Exit from the programme");
                        Console.WriteLine("Please select one of the options: ");
                        int user_chioce = Convert.ToInt32(Console.ReadLine());

                        switch (user_chioce)
                        {
                            case 1:
                                StudentsManager.AddStudent();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 2:
                                StudentsManager.UpdateStudent();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 3:
                                StudentsManager.DeleteStudent();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 4:
                                TrainerManager.AddTrainer();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 5:
                                TrainerManager.UpdateTrainer();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 6:
                                TrainerManager.DeleteTrainer();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 7:
                                CourseManager.AddCourse();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 8:
                                CourseManager.UpdateCourse();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 9:
                                CourseManager.DeleteCourse();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 10:
                                AssignmentManager.AddAssignment();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 11:
                                AssignmentManager.UpdateAssignment();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 12:
                                AssignmentManager.DeleteAssignment();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 13:
                                HeadMasterManager.AddHeadMaster();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 14:
                                HeadMasterManager.DeleteHeadMaster();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 15:
                                StudentsManager.RelateStudentsCourses();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 16:
                                StudentsManager.UNRelateStudentsCourses();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 17:
                                TrainerManager.RelateCoursesToTrainers();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 18:
                                TrainerManager.UNRelateCoursesToTrainers();  
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 19:
                                CourseManager.RelateAssignmentsToCourses();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 20:
                                CourseManager.UNRelateAssignmentsToCourses();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 21:
                                StudentsManager.RelateStudentsAssignments();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            case 22:
                                StudentsManager.UNRelateStudentsAssignments();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;


                            case 23:
                                Environment.Exit(0);
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Wrong input");
                    }




                }
            }
        }
    }
}
