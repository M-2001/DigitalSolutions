using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalSolutions.Domain;

namespace DigitalSolutions.Services
{
    public sealed class CustomerEntryModel: EntityTypeConfiguration<CustomerEntry>
    {
        public CustomerEntryModel()
        {
            this.HasKey(b => b.ID);

            this.Property(b => b.name).HasMaxLength(200).IsRequired();
            this.Property(b => b.company).HasMaxLength(20).IsRequired();

            this.Property(b => b.email).HasMaxLength(20).IsRequired();
            this.Property(b => b.phoneNumber).HasMaxLength(20).IsRequired();
            this.Property(b => b.message).HasMaxLength(20).IsRequired();
            this.Property(b => b.enabled).IsRequired();
            this.Property(b => b.createDate).IsRequired();

        }
    }
}
