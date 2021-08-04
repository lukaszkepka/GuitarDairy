using GuitarDairy.Domain.Entities;
using GuitarDairy.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GuitarDairy.Infrastructure.EF.Mapping
{
    public class EntryMap : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Relationship
            builder.HasOne(t => t.Exercise)
                .WithMany(t => t.Entries)
                .HasForeignKey(t => t.ExerciseId);

            // Properties
            builder.Property(e => e.Date)
                .HasConversion(x => (DateTime)x, y => y);
        }
    }
}
