using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPage.Domain;



namespace MyPage.Services
{
    public sealed class BlogEntryModel : EntityTypeConfiguration<BlogEntry>
    {
        public BlogEntryModel()
        {
            this.HasKey(b => b.ID);

            this.Property(b => b.name).HasMaxLength(200).IsRequired();
            this.Property(b => b.createDate).IsRequired();

            this.Property(b => b.enabled).IsRequired();
            this.Property(b => b.published).IsRequired();
            this.Property(b => b.description).IsRequired();

        }
    }

}
