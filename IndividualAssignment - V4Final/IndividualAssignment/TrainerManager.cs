using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    class TrainerManager
    {

        public static void AddTrainer()
        {

            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.Write("Please input the First Name of the trainer: ");
                    string first_input = Console.ReadLine();
                    Console.Write("Please input the Last Name of the trainer: ");
                    string last_input = Console.ReadLine();
                    Console.Write("Please input the Name of the Subject the trainer teaches: ");
                    string subject_input = Console.ReadLine();
                    Console.Write("Please input the password of the trainer's account: ");
                    string password_input = Console.ReadLine();
                    double HashedPassword = Hashing.HashingMethod(password_input);

                    Trainer T = new Trainer();
                    {
                        T.FirstName = first_input;
                        T.LastName = last_input;
                        T.Subject = subject_input;
                        T.Password = HashedPassword;
                    
                    }
                    using (MyContext db = new MyContext())
                    {
                        db.Trainers.Add(T);
                        db.SaveChanges();
                    }
                    Console.Write("\nTrainer has been succesfully added\n");
                    loop = false;

                }
                catch (Exception)
                {

                    Console.WriteLine("\nTRAINER HAS NOT ADDED\nPlease enter the inputs in the CORRECT FORM\n"); ;
                }
            }
        }

        public static void GetAllTrainers()
        {
            using (MyContext db = new MyContext())
            {
                List<Trainer> a = db.Trainers.OrderBy(x => x.LastName).ToList();
                Trainer S = new Trainer();
                Console.WriteLine("TRAINERS LIST");
                S.PrintTrainers(a);

            }
        }

        public static void DeleteTrainer()
        {
            using (MyContext db = new MyContext())
            {
                List<Trainer> a = db.Trainers.OrderBy(x => x.LastName).ToList();
                Trainer S = new Trainer();
                S.PrintTrainers(a);
                Console.Write("Please select the ID of the trainer you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Trainer T1 = db.Trainers.Find(id);
                Console.WriteLine($"The trainer {T1.FirstName} {T1.LastName} has been removed");
                db.Trainers.Remove(T1);
                db.SaveChanges();
            }
        }

        public static void UpdateTrainer()
        {
            using (MyContext db = new MyContext())
            {
                List<Trainer> a = db.Trainers.OrderBy(x => x.LastName).ToList();
                Trainer S = new Trainer();
                S.PrintTrainers(a);
                Console.Write("Please select the ID of the trainer you want to uddate: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Trainer T1 = db.Trainers.Find(id);
                Console.WriteLine("Which attribute you want to update?");
                Console.WriteLine("1 - First Name\n2 - Last Name\n3 - Subject\n4 - Password");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter new name");
                        T1.FirstName = Console.ReadLine();

                        break;
                    case 2:
                        Console.WriteLine("Please enter new name");
                        T1.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Please enter new Subject");
                        T1.Subject = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Please enter new Password");
                        string input = Console.ReadLine();
                        double Hashedinput = Hashing.HashingMethod(input);
                        T1.Password = Hashedinput;
                        break;


                }
                Console.WriteLine("Changes Saved");
                db.SaveChanges();

            }
        }

        public static void RelateAssignmentsToTrainers()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine("Please add Assignment to the Trainer using the ID's from the lists");
                GetAllTrainers();
                AssignmentManager.GetAllAssignments();
                Console.Write("Select the Trainer id from the list you want to add an assignment: ");
                int id_t = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select the Assignment id from the list you want to add to the course: ");
                int id_a = Convert.ToInt32(Console.ReadLine());
                Trainer T = new Trainer();
                Trainer T1 = db.Trainers.Find(id_t);
                Assignment A = new Assignment();
                Assignment A1 = db.Assignments.Find(id_a);
                T1.Assignments.Add(A1);
                db.SaveChanges();
                Console.WriteLine("\nAssignment successfully submitted to the trainer");


            }

        }

        public static void RelateCoursesToTrainers()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine("Please add Course to the Trainer using the ID's from the lists");
                GetAllTrainers();
                CourseManager.GetAllCourses();
                Console.Write("Select the Trainer id from the list you want to add a course: ");
                int id_t = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select the Course id from the list you want to add to the Trainer: ");
                int id_c = Convert.ToInt32(Console.ReadLine());
                Trainer T = new Trainer();
                Trainer T1 = db.Trainers.Find(id_t);
                Course C = new Course();
                Course C1 = db.Courses.Find(id_c);
                T1.Courses.Add(C1);
                db.SaveChanges();
                Console.WriteLine("\nCourse successfully submitted to the trainer");


            }

        }

        public static void UNRelateCoursesToTrainers()
        {
            using (MyContext db = new MyContext())
            {
                Console.WriteLine($"{"Trainer ID",-10}  {"First Name",-10}  {"Last Name",15}  {"Course ID",-10}  {"Course Title",-15}");

                foreach (var x in db.Trainers)
                {
                    foreach (var y in x.Courses)
                    {
                        Console.WriteLine($"{x.TrainerID,-10}  {x.FirstName,-10}  {x.LastName,15}  {y.CourseID,-10}  {y.Title,-15}");
                    }

                }

                Console.WriteLine("Select the Course and the Trainer to un-relate using the ID's from the list"); 
                Console.Write("Select the Trainer id from the list: ");
                int id_t = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select the Course id from the list: ");
                int id_c = Convert.ToInt32(Console.ReadLine());              
                Trainer T1 = db.Trainers.Find(id_t);                
                Course C1 = db.Courses.Find(id_c);
                T1.Courses.Remove(C1);
                db.SaveChanges();
                Console.WriteLine("\nCourse successfully removed from the trainer");


            }

        }







    }
}
