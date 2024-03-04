using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("PRODUCTS")]
    public class Products
    {
        [Key]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string productCode { get; set; }

        [StringLength(70)]
        [Column(TypeName = "varchar(70)")]
        public string productName { get; set; }

        [ForeignKey("productLines")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string productLine { get; set; }
        public ProductLines productLines { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string productScale { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string productVendor { get; set; }

        [Column(TypeName = "text")]
        public string productDescription { get; set; }

        [Column(TypeName = "smallint(6)")]
        public int quantityStock { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double buyPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double MSRP { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }


        public Products(string productCode, string productName, string productLine, string productScale,
                    string productVendor, string productDescription, int quantityStock, double buyPrice, double MSRP)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.productLine = productLine;
            this.productScale = productScale;
            this.productVendor = productVendor;
            this.productDescription = productDescription;
            this.quantityStock = quantityStock;
            this.buyPrice = buyPrice;
            this.MSRP = MSRP;
        }
    }
}
