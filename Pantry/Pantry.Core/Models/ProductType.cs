using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantry.Core.Models

{
    public class ProductType 
    { 
        public string ID {  get; set; }
        public string Type { get; set; }

        public ProductType() { 
            this.ID = Guid.NewGuid().ToString();
        }
    }

}
