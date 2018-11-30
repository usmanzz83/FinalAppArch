
using System;
using System.Collections.Generic;

using Repository.Pattern.Ef6;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Application.Entities.Entities
{
    public partial class Category : Entity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryID { get; set; }

        [Required(ErrorMessage ="ECategory name is a required feild.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "ECategory description is a required feild.")]
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
