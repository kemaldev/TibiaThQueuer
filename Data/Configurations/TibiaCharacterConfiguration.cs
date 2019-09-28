using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class TibiaCharacterConfiguration : IEntityTypeConfiguration<TibiaCharacter>
    {
        public void Configure(EntityTypeBuilder<TibiaCharacter> builder)
        {
            builder.ToTable(nameof(TibiaCharacter));
            builder
                .HasKey(tibiaCharacter => tibiaCharacter.TibiaCharacterId);
            builder.Property(tibiaCharacter => tibiaCharacter.TibiaCharacterId).IsRequired();
        }
    }
}
