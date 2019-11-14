using System.Data.Entity;
using System.Reflection;

namespace SchoolService
{
    public class DataContext:DbContext
    {
        public DataContext() : base("name=conn")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载EF数据库映射配置
            //从当前代码所在的程序集记载配置
            modelBuilder.Configurations.AddFromAssembly
                (Assembly.GetExecutingAssembly());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<MinZu> MinZu { get; set; }
        public DbSet<Class> Class { get; set; }
    }
}
