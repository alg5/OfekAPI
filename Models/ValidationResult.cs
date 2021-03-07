using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfekCore.Models
{
    [Flags]
    public enum ValidationResult
    {
        Ok = 0,
        [Display(Name = "לקוח לא קיים")]
        ProductNotFound = 1,
        CustomerNotFound = 2,
        SumNegative = 4,
        SumNotNumber = 8,
//        Ok = 16
    }
}
