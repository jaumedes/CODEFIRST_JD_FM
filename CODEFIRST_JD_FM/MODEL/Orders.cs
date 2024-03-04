using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("ORDERS")]

    public class Orders
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int orderNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime orderDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime requiredDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime shippedDate { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string status { get; set; }

        [Column(TypeName = "text")]
        public string? comments { get; set; }

        [ForeignKey("Customers")]
        [Column(TypeName = "INT(11)")]
        public int? customerNumber { get; set; }
        public Customers? Customers { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Orders(int orderNumber, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, string status, string? comments, int? customerNumber)
        {
            this.orderNumber = orderNumber;
            this.orderDate = orderDate;
            this.requiredDate = requiredDate;
            this.shippedDate = shippedDate;
            this.status = status;
            this.comments = comments;
            this.customerNumber = customerNumber;
        }
    }
}
