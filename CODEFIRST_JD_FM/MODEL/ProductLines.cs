using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("PRODUCTLINES")]

    public class ProductLines
    {
        [Key]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string productLineName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(4000)")]
        public string textDescription { get; set; }

        [Column(TypeName = "mediumtext")]
        public string? htmlDescription { get; set; }

        [Column(TypeName = "mediumblob")]
        public byte[]? image { get; set; }

        public ICollection<Products> Products { get; set; }


        public ProductLines(string productLineName, string textDescription, string? htmlDescription, byte[]? image)
        {
            this.productLineName = productLineName;
            this.textDescription = textDescription;
            this.htmlDescription = htmlDescription;
            this.image = image;
        }
    }
}
