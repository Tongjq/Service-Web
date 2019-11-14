using System.Data.Entity.ModelConfiguration;

namespace SchoolService.EntityConfig
{
    public class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            ToTable("T_Classes");
            Property(e => e.Name).HasMaxLength(20).IsRequired();
        }
    }
}
