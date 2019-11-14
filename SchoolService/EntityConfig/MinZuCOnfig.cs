using System.Data.Entity.ModelConfiguration;

namespace SchoolService.EntityConfig
{
    public class MinZuConfig:EntityTypeConfiguration<MinZu>
    {
        public MinZuConfig()
        {
            ToTable("T_MinZus");
            Property(e => e.Name).HasMaxLength(20).IsRequired();
        }
    }
}
