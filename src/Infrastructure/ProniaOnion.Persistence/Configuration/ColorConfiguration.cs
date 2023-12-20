using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Configuration
{
    public class ColorConfiguration:IEntityTypeConfiguration<Color>
    {

        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
