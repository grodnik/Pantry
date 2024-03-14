using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantry.Core.Models
{
  public class Product : BaseEntity
  {
    [StringLength(30)]
    [DisplayName("Item Name")]
    public string Name { get; set; }

    public string Type { get; set; }              /* Pantry/Kitchen/Meal */

    public string Category { get; set; }          /* Detail of Type */

    [Range(0,100)]
    public decimal Price { get; set; }

  }
}
