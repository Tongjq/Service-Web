using SchoolService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class ClassService
    {
        public IEnumerable<ClassDTO> GetAll()
        {
            using (DataContext ctx = new DataContext())
            {
                List<ClassDTO> list = new List<ClassDTO>();
                foreach (var c in ctx.Class)
                {
                    ClassDTO dto = new ClassDTO();
                    dto.Id = c.Id;
                    dto.Name = c.Name;
                    list.Add(dto);
                }
                return list;

            }
        }
    }
}
