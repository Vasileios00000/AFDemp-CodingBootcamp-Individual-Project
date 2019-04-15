using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment.Users
{
    public class Passwords
    {
        public Student userS { get; set; }
        public HeadMaster userHM { get; set; }
        public Trainer userT { get; set; }
        public string type_user { get; set; }
        public int user_id { get; set; }

        public void PasswordTry()
        {
            bool a = true;                      
            //string type_user="";
          
            Console.WriteLine("Welcome to the school programme!\n\nPlease enter your Surname and your Password to log-in\nWatch-out you have only 3 attempts\n");
            for (int i = 0; i < 3; i++)
            {
                while (a)
                {
                    try
                    {

                    


                        Console.Write("Please enter your Surname: ");
                        string surname_input = Console.ReadLine();
                        Console.Write("Please enter your password: ");
                        string password_input = Console.ReadLine();

                        using (MyContext db = new MyContext())
                        {

                            foreach (var x in db.Students)
                            {
                                if (x.LastName == surname_input && x.Password == Hashing.HashingMethod(password_input))
                                {
                                    Console.WriteLine($"\nStudent {x.FirstName} {x.LastName} successfully logged in");
                                    a = false;
                                    type_user = "Student";
                                    user_id = x.StudentID;
                                    userS = x;
                                    break;


                                }

                            }

                            foreach (var x in db.Trainers)
                            {
                                if (x.LastName == surname_input && x.Password == Hashing.HashingMethod(password_input))
                                {
                                    Console.WriteLine($"\nTrainer {x.FirstName} {x.LastName} successfully logged in");
                                    a = false;
                                    type_user = "Trainer";
                                    userT = x;
                                    user_id = x.TrainerID;




                                }
                            }

                            foreach (var x in db.HeadMasters)
                            {
                                if (x.LastName == surname_input && x.Password == Hashing.HashingMethod(password_input))
                                {
                                    Console.WriteLine($"\nHead Master {x.FirstName} {x.LastName} successfully logged in");
                                    a = false;
                                    type_user = "Head_Master";
                                    userHM = x;
                                    user_id = x.HeadMasterID;


                                }
                            }



                            if (a == true)
                            {
                                Console.WriteLine("Wrong log in details.Please try again");
                                break;

                            }
                        }

                    }
                     catch (Exception)
                    {

                        throw;
                    }



                }          
            }     

        }       
    }
}
