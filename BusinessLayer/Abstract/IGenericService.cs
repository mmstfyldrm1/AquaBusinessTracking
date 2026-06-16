using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<TDto, TCreateDto, TUpdateDto>
    {
        Task<List<TDto>> GetList();
        Task<TDto> GetById(int id);
        Task<TDto> Add(TCreateDto dto);
        Task Update(TUpdateDto dto);
        Task Delete(int id);
    }
}
