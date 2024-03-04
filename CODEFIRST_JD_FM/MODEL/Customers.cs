using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("CUSTOMERS")]
    public class Customers
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int customerNumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string customerName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string contactLastName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string ContactFirstName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string phone { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string addressLine1 { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string addressLine2 { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string city { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string state { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar(50)")]
        public string postalCode { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string country { get; set; }

        [ForeignKey("Employees")]
        [Column(TypeName = "INT(11)")]
        public int? salesRepEmployeeNumber { get; set; }
        public Employees? Employees { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double creditLimit { get; set; }

        public ICollection<Payments> Payments { get; set; }
        public ICollection<Orders> Orders { get; set; }

        public Customers() { }

        public Customers(int customerNumber, string customerName, string contactLastName, string contactFirstName, string phone, string addressLine1,
                        string addressLine2, string city, string state, string postalCode, string country, int? salesRepEmployeeNumber, double creditLimit)
        {
            this.customerNumber = customerNumber;
            this.customerName = customerName;
            this.contactLastName = contactLastName;
            this.ContactFirstName = contactFirstName;
            this.phone = phone;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.country = country;
            this.salesRepEmployeeNumber = salesRepEmployeeNumber;
            this.creditLimit = creditLimit;
        }
    }
}
