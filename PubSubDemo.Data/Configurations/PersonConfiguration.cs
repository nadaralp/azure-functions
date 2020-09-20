using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PubSubDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDemo.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable("people")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Age)
                .HasColumnName("age")
                .IsRequired();

            builder
                .Property(x => x.RegisterDare)
                .HasColumnName("register_date")
                .HasDefaultValue(DateTime.Now);
                
        }
    }
}
