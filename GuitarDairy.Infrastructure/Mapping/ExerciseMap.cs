using GuitarDairy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuitarDairy.Infrastructure.EF.Mapping
{
    public class ExerciseMap : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Relationship
            builder.HasOne(t => t.Category)
                .WithMany(t => t.Exercises)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
