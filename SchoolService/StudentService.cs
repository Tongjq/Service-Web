using SchoolService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SchoolService
{
    public class StudentService
    {
        public void AddNew(string name, int age, long minZuId, long classId)
        {
            using (DataContext dbContext = new DataContext())
            {
                Student studentDTO = new Student();
                studentDTO.Name = name;
                studentDTO.Age = age;
                studentDTO.MinZuId = minZuId;
                studentDTO.ClassId = classId;
                dbContext.Students.Add(studentDTO);
                dbContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {

            using (DataContext ctx = new DataContext())
            {
                /*var stu = ctx.Students.SingleOrDefault(s=>s.Id==id);
                if (stu == null)
                {
                    throw new ArgumentException("没找到id="+id+"学生");
                }
                ctx.Students.Remove(stu);*/

                Student stu = new Student();
                stu.Id = id;
                ctx.Entry(stu).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();

            }
        }

        public StudentDTO GetById(long id)
        {
            using (DataContext ctx = new DataContext())
            {
                var s = ctx.Students.AsNoTracking()
                    .Include(e=>e.MinZu)
                    .Include(e=>e.Class)
                    .SingleOrDefault(e => e.Id == id);
                if (s == null)
                {
                    return null;
                }

                StudentDTO dto = new StudentDTO();
                dto.Age = s.Age;
                dto.ClassId = s.ClassId;
                dto.ClassName = s.Class.Name;
                dto.Id = s.Id;
                dto.MinZuId = s.MinZuId;
                dto.MinZuName = s.MinZu.Name;
                dto.Name = s.Name;
                return dto;
            }
        }


        public IEnumerable<StudentDTO> GetByClassId(long classId)
        {
            using (DataContext ctx = new DataContext())
            {
                var students = ctx.Students.AsNoTracking()
                    .Include(s => s.Class)
                    .Include(s => s.MinZu)
                    .Where(s => s.ClassId == classId);
                List<StudentDTO> dtoList = new List<StudentDTO>();
                foreach (var student in students)
                {
                    StudentDTO dto = new StudentDTO();
                    dto.Age = student.Age;
                    dto.ClassId = student.ClassId;
                    dto.ClassName = student.Class.Name;
                    dto.Id = student.Id;
                    dto.MinZuId = student.MinZuId;
                    dto.MinZuName = student.MinZu.Name;
                    dto.Name = student.Name;
                }

                return dtoList;
            }
             
        }
    }
}
