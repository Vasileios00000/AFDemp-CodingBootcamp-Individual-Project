using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public double Password { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }


        public void PrintTrainers(List<Trainer> list)
        {
            Console.WriteLine($"{"ID",-3}  {"Fisrt Name",-11}  {"Last Name",-11}  {"Subject",-15}");
            foreach (var x in list)
            {
                Console.WriteLine($"{x.TrainerID,-3}  {x.FirstName,-11}  {x.LastName,-11}  {x.Subject,-15}");

            }
        }




    }
}
