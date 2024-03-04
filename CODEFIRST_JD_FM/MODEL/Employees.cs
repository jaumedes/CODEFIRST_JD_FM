using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{

    [Table("EMPLOYEES")]
    public class Employees
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int employeeNumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String lastName { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String firstName { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public String extension { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(100)")]
        public String email { get; set; }

        [ForeignKey("Offices")]
        [StringLength(50)]
        [Column(TypeName = "varchar(10)")]
        public string officeCode { get; set; }
        public Offices Offices { get; set; }

        [ForeignKey("employeesToReport")]
        [Column(TypeName = "INT(11)")]
        public int? reportsTo { get; set; }
        public Employees? employeesToReport { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string jobTitle { get; set; }

        public ICollection<Customers> Customers { get; set; }

        public Employees() { }

        public Employees(int employeeNumber, string lastName, string firstName, string extension, string email, string officeCode, int? reportsTo, string jobTitle)
        {
            this.employeeNumber = employeeNumber;
            this.lastName = lastName;
            this.firstName = firstName;
            this.extension = extension;
            this.email = email;
            this.officeCode = officeCode;
            this.reportsTo = reportsTo;
            this.jobTitle = jobTitle;
        }
    }    
}
