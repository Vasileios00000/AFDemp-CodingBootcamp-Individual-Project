using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualAssignment.Models
{
    public class Course
    {
  
        public int CourseID { get; set; }

        public string Title { get; set; }
        public bool Stream { get; set; }
        public bool Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }




        public void PrintCourses(List<Course> list)
        {
            

            Console.WriteLine($"{"ID",-3}  {"Title",-11}  {"Stream",-11}  {"Type",-10}  {"StartTime",-15}  {"EndTime",-15}");
            foreach (var x in list)
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
