using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Try3.Models
{

        [Table("Department", Schema = "College")]
        public class Department
        {
            [Key] // PrimaryKey
            [Display(Name = "Department Id")] // showing in field
            public int departmentId { get; set; }

            [Required]
            [Display(Name = "Department Name")] // showing in field
            [Column(TypeName = "varchar(200)")]
            public string departmentName { get; set; } = string.Empty;
        }
}
