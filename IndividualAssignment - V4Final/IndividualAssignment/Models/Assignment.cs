using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IndividualAssignment.Models
{
    public class Assignment
    {
        
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDateAndTime { get; set; }


        
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }








        public void PrintAssignments(List<Assignment> list)
        {
            Console.WriteLine($"{"ID",-3}  {"Title",-11}  {"Description",-20}  {"Date and Time Of Submission",-15}");
            foreach (var x in list)
            {
                Console.WriteLine($"{x.AssignmentID,-3}  {x.Title,-11}  {x.Description,-20}  {x.SubmissionDateAndTime,-15}");

            }

        }
    }

}
