using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.Models
{
    public class Cart :BaseModel
    {
       
        public bool checkedOut { get; set; }
        [Column(TypeName = "money")]
        public decimal total { get; set; }
        public ICollection<LineItem> LineItems { get; set; }

    }
}
