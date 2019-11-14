using System.Data.Entity.ModelConfiguration;

namespace SchoolService.EntityConfig
{
    public class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("T_Students");
            Property(e => e.Name).HasMaxLength(20).IsRequired();
            Property(e => e.Age).IsRequired();
            HasRequired(e => e.Class).WithMany()
                .HasForeignKey(e=>e.ClassId);
            HasRequired(e => e.MinZu).WithMany()
                .HasForeignKey(e => e.MinZuId);

        }
    }
}
