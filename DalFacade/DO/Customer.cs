using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// ישות לקוח בחנות תכשיטים
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="Address"></param>
    /// <param name="Phone"></param>
    public record Customer
   (
        int Id,
        string Name,
        string? Address,
        string Phone
        )
    {
        /// <summary>
        /// בנאי המאתחל ערכים
        /// </summary>
        public Customer():this(0,"",null, "")
        {
            
        }
    }
}
