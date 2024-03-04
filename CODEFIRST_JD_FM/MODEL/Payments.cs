using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("PAYMENTS")]

    public class Payments
    {
        [Column(TypeName = "INT(11)")]
        public int customerNumber { get; set; }
        public Customers Customers { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string checkNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime paymentDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double amount { get; set; }

        public Payments() { }

        public Payments(int customerNumber, string checkNumber, DateTime paymentDate, double amount)
        {
            this.customerNumber = customerNumber;
            this.checkNumber = checkNumber;
            this.paymentDate = paymentDate;
            this.amount = amount;
        }
    }
}
