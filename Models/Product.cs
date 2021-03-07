using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OfekCore.Models
{
    [Serializable]
    public class Product
    {
        [MaxLength(128)]
        public string ProductID { get; set; }

        [MaxLength(128)]
        [Display(Name = "מכון פיננסי")]
        public string FinanceInstitue { get; set; }

        [MaxLength(128)]
        [Display(Name = "סוג מוצר")]
        public string ProductType { get; set; }

        [MaxLength(128)]
        public string InvestType { get; set; }

        public DateTime? CreatedDate { get; set; }

      //  public virtual CustomerProduct customerProduct { get; set; }



    }
}
