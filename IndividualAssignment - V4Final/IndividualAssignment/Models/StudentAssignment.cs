using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace IndividualAssignment.Models
{
    public class StudentAssignment
    {

        public StudentAssignment()
        {
            SubmittedYesorNo = "No";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column(Order = 0)]
        public int StudentID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column(Order = 1)]
        public int AssignmentID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Assignment Assignment { get; set; }

        public string SubmittedYesorNo { get; set; }

        public int Mark { get; set; }

     


    }
}
