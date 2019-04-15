using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    public static class Popullate
    {

        public static void AddRandomData()
        {

            using (MyContext db = new MyContext())
            {

                Student S = new Student();

                S.FirstName = "Petros";
                S.LastName = "Petrou";
                S.DateOfBirth = new DateTime(1985, 3, 4);
                S.TuitionFees = 767;
                S.Password = Hashing.HashingMethod("petpet");
                if (!db.Students.Any(x => x.Password == S.Password))
                {
                    db.Students.Add(S);
                    db.SaveChanges();
                }

                Student S1 = new Student();

                S1.FirstName = "Vasilis";
                S1.LastName = "Georgilas";
                S1.DateOfBirth = new DateTime(1985, 7, 9);
                S1.TuitionFees = 2200;
                S1.Password = Hashing.HashingMethod("vasgeo");
                if (!db.Students.Any(x => x.Password == S1.Password))
                {
                    db.Students.Add(S1);
                    db.SaveChanges();
                }

                Student S2 = new Student();

                S2.FirstName = "Giannis";
                S2.LastName = "Daskalakis";
                S2.DateOfBirth = new DateTime(1989, 9, 24);
                S2.TuitionFees = 2200;
                S2.Password = Hashing.HashingMethod("giadas");
                if (!db.Students.Any(x => x.Password == S2.Password))
                {
                    db.Students.Add(S2);
                    db.SaveChanges();
                }

                Student S3 = new Student();

                S3.FirstName = "Vaggelis";
                S3.LastName = "Roditis";
                S3.DateOfBirth = new DateTime(1978, 7, 9);
                S3.TuitionFees = 4300;
                S3.Password = Hashing.HashingMethod("vagrod");
                if (!db.Students.Any(x => x.Password == S3.Password))
                {
                    db.Students.Add(S3);
                    db.SaveChanges();
                }
                Student S4 = new Student();

                S4.FirstName = "Makis";
                S4.LastName = "Vasilakis";
                S4.DateOfBirth = new DateTime(1969, 3, 12);
                S4.TuitionFees = 2200;
                S4.Password = Hashing.HashingMethod("makvas");
                if (!db.Students.Any(x => x.Password == S4.Password))
                {
                    db.Students.Add(S4);
                    db.SaveChanges();
                }

                //TRAINERS
                Trainer T = new Trainer();

                T.FirstName = "Vyron";
                T.LastName = "Vasileiadis";
                T.Subject = "Exercises";
                T.Password = Hashing.HashingMethod("vyrvas");
                if (!db.Trainers.Any(x => x.Password == T.Password))
                {
                    db.Trainers.Add(T);
                    db.SaveChanges();
                }

                Trainer T1 = new Trainer();

                T1.FirstName = "Michalis";
                T1.LastName = "Nikolaidis";
                T1.Subject = "Theory";
                T1.Password = Hashing.HashingMethod("micnik");
                if (!db.Trainers.Any(x => x.Password == T1.Password))
                {
                    db.Trainers.Add(T1);
                    db.SaveChanges();
                }

                Trainer T2 = new Trainer();

                T2.FirstName = "Giannis";
                T2.LastName = "Panagopoulos";
                T2.Subject = "Adv.Theory";
                T2.Password = Hashing.HashingMethod("gianpan");
                if (!db.Trainers.Any(x => x.Password == T2.Password))
                {
                    db.Trainers.Add(T2);
                    db.SaveChanges();
                }

                //COURSES

                Course C = new Course();

                C.Title = "C# Basics";
                C.Stream = false;
                C.Type = true;
                C.StartTime = new DateTime(2019, 6, 1);
                C.EndTime = new DateTime(2019, 7, 1);

                if (!db.Courses.Any(x => x.Title == C.Title))
                {
                    db.Courses.Add(C);
                    db.SaveChanges();
                }

                Course C1 = new Course();

                C1.Title = "C# Adv.";
                C1.Stream = false;
                C1.Type = true;
                C1.StartTime = new DateTime(2019, 7, 1);
                C1.EndTime = new DateTime(2019, 8, 1);

                if (!db.Courses.Any(x => x.Title == C1.Title))
                {
                    db.Courses.Add(C1);
                    db.SaveChanges();
                }

                Course C2 = new Course();

                C2.Title = "MySQL";
                C2.Stream = false;
                C2.Type = true;
                C2.StartTime = new DateTime(2019, 6, 1);
                C2.EndTime = new DateTime(2019, 7, 1);

                if (!db.Courses.Any(x => x.Title == C2.Title))
                {
                    db.Courses.Add(C2);
                    db.SaveChanges();
                }

                Course C3 = new Course();

                C3.Title = "Java Basics";
                C3.Stream = true;
                C3.Type = true;
                C3.StartTime = new DateTime(2019, 6, 1);
                C3.EndTime = new DateTime(2019, 7, 1);

                if (!db.Courses.Any(x => x.Title == C3.Title))
                {
                    db.Courses.Add(C3);
                    db.SaveChanges();
                }

                //ASSIGNMENTS

                Assignment A = new Assignment();

                A.Title = "Assignment 1";
                A.Description = "School Project";
                A.SubmissionDateAndTime = new DateTime(2019, 6, 15);


                if (!db.Assignments.Any(x => x.Title == A.Title))
                {
                    db.Assignments.Add(A);
                    db.SaveChanges();
                }

                Assignment A1 = new Assignment();

                A1.Title = "Assignment 2";
                A1.Description = "Build a website";
                A1.SubmissionDateAndTime = new DateTime(2019, 6, 28);


                if (!db.Assignments.Any(x => x.Title == A1.Title))
                {
                    db.Assignments.Add(A1);
                    db.SaveChanges();
                }

                Assignment A2 = new Assignment();

                A2.Title = "Assignment 3";
                A2.Description = "Final Project";
                A2.SubmissionDateAndTime = new DateTime(2019, 8, 12);


                if (!db.Assignments.Any(x => x.Title == A2.Title))
                {
                    db.Assignments.Add(A2);
                    db.SaveChanges();
                }


                //HEAD MASTER

                HeadMaster H_D = new HeadMaster();

                H_D.FirstName = "Giorgos";
                H_D.LastName = "Pasparakis";
                H_D.Password = Hashing.HashingMethod("giopas");


                if (!db.HeadMasters.Any(x => x.Password == H_D.Password))
                {
                    db.HeadMasters.Add(H_D);
                    db.SaveChanges();
                }
            }
        }


        public static void AddRandomData2()
        {

            using (MyContext db = new MyContext())
            {

                //COURSESnSTUDENTS

                Student Petrou = new Student();
                Petrou = db.Students.Where(x => x.LastName == "Petrou").FirstOrDefault();
                Student Georgilas = new Student();
                Georgilas = db.Students.Where(x => x.LastName == "Georgilas").FirstOrDefault();
                Student Roditis = new Student();
                Roditis = db.Students.Where(x => x.LastName == "Roditis").FirstOrDefault();
                Student Vasilakis = new Student();
                Vasilakis = db.Students.Where(x => x.LastName == "Vasilakis").FirstOrDefault();
                Course CCC = new Course();
                CCC = db.Courses.Where(x => x.Title == "C# Basics").FirstOrDefault();
                Course CCC1 = new Course();
                CCC1 = db.Courses.Where(x => x.Title == "C# Adv.").FirstOrDefault();
                Course CCC2 = new Course();
                CCC2 = db.Courses.Where(x => x.Title == "MySQL").FirstOrDefault();
                Course CCC3 = new Course();
                CCC3 = db.Courses.Where(x => x.Title == "Java Basics").FirstOrDefault();

                Petrou.Courses.Add(CCC);
                Petrou.Courses.Add(CCC1);
                Georgilas.Courses.Add(CCC);
                Georgilas.Courses.Add(CCC2);
                Roditis.Courses.Add(CCC);
                Roditis.Courses.Add(CCC2);
                Roditis.Courses.Add(CCC3);
                Vasilakis.Courses.Add(CCC);
                Vasilakis.Courses.Add(CCC1);
                Vasilakis.Courses.Add(CCC2);
                Vasilakis.Courses.Add(CCC3);


                

                //TRAINER n COURSES

                Trainer Nikolaidis = new Trainer();
                Nikolaidis = db.Trainers.Where(x => x.LastName == "Nikolaidis").FirstOrDefault();
                Trainer Panagopoulos = new Trainer();
                Panagopoulos = db.Trainers.Where(x => x.LastName == "Panagopoulos").FirstOrDefault();
                Trainer Vasileiadis = new Trainer();
                Vasileiadis = db.Trainers.Where(x => x.LastName == "Vasileiadis").FirstOrDefault();

                Nikolaidis.Courses.Add(CCC);               
                Panagopoulos.Courses.Add(CCC2);             
                Vasileiadis.Courses.Add(CCC3);             
                Vasileiadis.Courses.Add(CCC1);

                db.SaveChanges();

                //Assignment n student

                Random R = new Random();

                

                if (db.StudentAssignments.ToList().Count==0)
                {
                    Assignment Ass1 = new Assignment();
                    Ass1 = db.Assignments.Where(x => x.Title == "Assignment 1").FirstOrDefault();

                    Assignment Ass2 = new Assignment();
                    Ass2 = db.Assignments.Where(x => x.Title == "Assignment 2").FirstOrDefault();


                    Assignment Ass3 = new Assignment();
                    Ass3 = db.Assignments.Where(x => x.Title == "Assignment 3").FirstOrDefault();


                    StudentAssignment SA = new StudentAssignment();
                    SA.AssignmentID = Ass1.AssignmentID;
                    SA.StudentID = Georgilas.StudentID;


                    StudentAssignment SA1 = new StudentAssignment();
                    SA1.AssignmentID = Ass2.AssignmentID;
                    SA1.StudentID = Georgilas.StudentID;

                    StudentAssignment SA2 = new StudentAssignment();
                    SA2.AssignmentID = Ass2.AssignmentID;
                    SA2.StudentID = Petrou.StudentID;

                    StudentAssignment SA3 = new StudentAssignment();
                    SA3.AssignmentID = Ass3.AssignmentID;
                    SA3.StudentID = Roditis.StudentID;


                    db.StudentAssignments.Add(SA);
                    db.StudentAssignments.Add(SA1);
                    db.StudentAssignments.Add(SA2);
                    db.StudentAssignments.Add(SA3);

                    db.SaveChanges();
                }


                //Assignment n Course
                Assignment A1 = new Assignment();
                A1 = db.Assignments.Where(x => x.Title == "Assignment 1").FirstOrDefault();

                Assignment A2 = new Assignment();
                A2 = db.Assignments.Where(x => x.Title == "Assignment 2").FirstOrDefault();


                Assignment A3 = new Assignment();
                A3 = db.Assignments.Where(x => x.Title == "Assignment 3").FirstOrDefault();

                CCC.Assignments.Add(A1);
                CCC.Assignments.Add(A2);              
                CCC1.Assignments.Add(A3);             
              

                db.SaveChanges();


            }












        }

        


    }
}
