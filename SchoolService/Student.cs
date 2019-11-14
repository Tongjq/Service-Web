namespace SchoolService
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long ClassId { get; set; }
        public Class Class { get; set; }
        public long MinZuId { get; set; }
        public MinZu MinZu { get; set; }
    }
}
