﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class CharacterListConfiguration : IEntityTypeConfiguration<CharacterList>
    {
        public void Configure(EntityTypeBuilder<CharacterList> builder)
        {
            builder.ToTable(nameof(CharacterList));
            
            builder
                .HasKey(characterList => characterList.CharacterListId);
            
            builder.Property(characterList => characterList.CharacterListId).IsRequired();

            builder.HasOne(characterList => characterList.Account)
                   .WithOne(account => account.CharacterList)
                   .HasForeignKey<Account>(account => account.CharacterListId);
        }
    }
}
