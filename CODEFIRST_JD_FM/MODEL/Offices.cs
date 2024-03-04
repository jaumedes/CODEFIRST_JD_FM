using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST_JD_FM.MODEL
{
    [Table("OFFICES")]

    public class Offices
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string officeCode { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String city { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String phone { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String addressLine1 { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String addressLine2 { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String state { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public String country { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public String postalCode { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public String territory { get; set; }

        public ICollection<Employees> Employees { get; set; }

        public Offices() { }

        public Offices(string officeCode, string city, string phone, string addressLine1, string addressLine2, string state, string country, string postalCode, string territory)
        {
            this.officeCode = officeCode;
            this.city = city;
            this.phone = phone;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.state = state;
            this.country = country;
            this.postalCode = postalCode;
            this.territory = territory;
        }
    }
}
