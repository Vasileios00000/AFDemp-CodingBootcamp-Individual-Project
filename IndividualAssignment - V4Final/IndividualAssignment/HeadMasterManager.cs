using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;

namespace IndividualAssignment
{
    static class HeadMasterManager
    {
        public static void AddHeadMaster()
        {
            Console.Write("Please insert the Fisrt Name of the Head Master: ");
            string firstname = Console.ReadLine();
            Console.Write("Please insert the surname of the Head Master: ");
            string surname = Console.ReadLine();
            Console.Write("Please insert the password of the Head Master's account: ");
            string password = Console.ReadLine();
            double password_hashed = Hashing.HashingMethod(password);





            using (MyContext db = new MyContext())
            {
                HeadMaster H = new HeadMaster();

                H.FirstName = firstname;
                H.LastName = surname;
                H.Password = password_hashed;             
                db.HeadMasters.Add(H);
                db.SaveChanges();
           
            }
            Console.WriteLine("Head Master successfully registered");

        }

        public static void DeleteHeadMaster()
        {
            
            using (MyContext db = new MyContext())
            {
                Console.WriteLine($"{"ID",-3}  {"First Name",-12}  {"Last Name",-12}");
                foreach (var x in db.HeadMasters)
                {
                    Console.WriteLine($"{x.HeadMasterID,-3}  {x.FirstName,-12}  {x.LastName,-12}");

                }
                Console.Write("Please select the id of the Head Master you want to remove: ");
                int id = Convert.ToInt32(Console.ReadLine());

                HeadMaster H = db.HeadMasters.Find(id);
                db.HeadMasters.Remove(H);
                db.SaveChanges();
            }
            Console.WriteLine("Head Master successfully deleted");

        }







    }
}
