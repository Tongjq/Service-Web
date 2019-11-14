using SchoolService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class MinZuService
    {
        public IEnumerable<MinZuDTO> GetAll()
        {
            using (DataContext ctx = new DataContext())
            {
                List<MinZuDTO> list = new List<MinZuDTO>();
                foreach (var mz in ctx.MinZu)
                {
                    MinZuDTO dto = new MinZuDTO();
                    dto.Id = mz.Id;
                    dto.Name = mz.Name;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
