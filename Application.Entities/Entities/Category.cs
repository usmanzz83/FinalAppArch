
using System;
using System.Collections.Generic;

using Repository.Pattern.Ef6;
using System.Data.Entity.Spatial;

namespace Application.Entities.Entities
{
    public partial class Category : Entity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
