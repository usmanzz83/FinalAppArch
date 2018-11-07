using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

namespace Application.Entities.Entities.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.HasKey(o => o.CategoryID);

            this.Property(o => o.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            //Table column mappings
            this.ToTable("Categories");
            this.Property(o => o.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Picture).HasColumnName("Picture");
        }
    }
}
