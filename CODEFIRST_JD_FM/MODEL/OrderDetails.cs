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
    [Table("ORDERDETAILS")]

    public class OrderDetails
    {

        [Column(TypeName = "INT(11)")]
        public int orderNumber { get; set; }
        public Orders Orders { get; set; }

        [ForeignKey("Products")]
        [StringLength(15)]
        [Column(TypeName = "varchar(50)")]
        public string? productCode { get; set; }
        public Products? Products { get; set; }

        [Column(TypeName = "INT(11)")]
        public int quantityOrdered { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double priceEach { get; set; }

        [Column(TypeName = "smallint(6)")]
        public int orderLineNumber { get; set; }

        public OrderDetails(int orderNumber, string productCode, int quantityOrdered, double priceEach, int orderLineNumber)
        {
            this.orderNumber = orderNumber;
            this.productCode = productCode;
            this.quantityOrdered = quantityOrdered;
            this.priceEach = priceEach;
            this.orderLineNumber = orderLineNumber;
        }
    }
}
