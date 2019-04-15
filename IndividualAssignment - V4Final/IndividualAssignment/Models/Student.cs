using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace IndividualAssignment.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TuitionFees { get; set; }

        public double Password { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }





        public void PrintStudents(List<Student> list)
        {
            Console.WriteLine($"{"ID",-3}  {"Fisrt Name",-11}  {"Last Name",-11}  {"Date Of Birth",-15}  {"Tuition Fees",-6}");
            foreach (var x in list)
            {
                Console.WriteLine($"{x.StudentID, -3}  {x.FirstName, -11}  {x.LastName, -11}  {x.DateOfBirth.Date.ToString("d"),-15}  {x.TuitionFees,-6}");

            }
            Console.WriteLine();
        }








    }
}
