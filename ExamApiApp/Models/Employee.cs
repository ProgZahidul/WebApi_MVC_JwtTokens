using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamApiApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string Address { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public int DesignationID {  get; set; }

        public decimal Salary { get; set; }

        public bool Permanent { get; set; }


        public virtual Designation Designation { get; set; }
        public virtual IList<Experience> Experiences { get; set; } = new List<Experience>();

    }
}