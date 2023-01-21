using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Try3.Models
{
    [Table("Student", Schema = "College")]
    public class Student
    {
        [Key] // PrimaryKey
        [MaxLength(4)]
        [MinLength(4)]
        [Column(TypeName = "int(4)")]
        [Display(Name = "Student Id")] // showing in field  
        public int? studentId { get; set; }  // the id is auto generating but here we but them to it is ok to e null to test the form and his validation 

        [Required] // not null and bydefault is req in validation and in form
        [Display(Name = "Student Name")] // showing in field
        [Column(TypeName = "varchar(200)")]
        public string studentName { get; set; } = string.Empty;

        [Display(Name = "Student Major ")] // showing in field
        [Column(TypeName = "varchar(200)")]
        public string? majorName { get; set; } = string.Empty;// Not Required  and have no valation i n input 

        [Display(Name = "birth Date")] // showing in field
        [DataType(DataType.Date)]
        public DateTime? birthDate { get; set; }


        //Realation between stu

        public int departmentId { get; set; }

        [ForeignKey("departmentId")]
        public Department? Department { get; set; }
    }
}
