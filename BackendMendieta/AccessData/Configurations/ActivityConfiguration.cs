using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessData.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            //builder.Property(x => x.ShortDescp).HasMaxLength(500).IsRequired();
        }
    }
}
