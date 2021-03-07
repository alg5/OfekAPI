using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OfekCore.Models
{
    [Serializable]
    public class CustomerProduct
    {

        [MaxLength(128)]
        public string CustomerProductID { get; set; }

        [MaxLength(128)]
        public string CustomerID { get; set; }

        [MaxLength(128)]
        [Display(Name = "חשבון")]
        [Range(1, 999999999, ErrorMessage = "החשבון לא חוקי")]
        public string AccountNumber { get; set; }

        [MaxLength(128)]
        public string ProductID { get; set; }
        [Range(1, 1000000, ErrorMessage = "סכום מקסימלי 1,000,000")]
        [Display(Name = "סכום")]
        public double? Sum { get; set; }

        [Display(Name = "סטטוס")]
        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public virtual Customer? customer { get; set; }

        public virtual Product? product { get; set; }
 


    }
}
