using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfekCore.Models
{
    [Serializable]
    public class Customer
    {
        [MaxLength(128)]
        public string CustomerID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(128)]
        [Display(Name = "שם לקוח")]
        public string FirstName { get; set; }

        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        [MaxLength(512)]
        [Display(Name = "עיר")]
        public string City { get; set; }
        [MaxLength(512)]
        [Display(Name = "כתובת")]
        public string Street { get; set; }
        [MaxLength(128)]
        public string HouseNumber { get; set; }

        [MaxLength(512)]
        [Display(Name = "דואר אלקטרוני")]
        public string PrivateEMail { get; set; }

        [Display(Name = "תאריך לידה")]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        //public virtual ICollection<CustomerProduct> customerProductList { get; set; }

        public Customer()
        {

        }


    }
}
