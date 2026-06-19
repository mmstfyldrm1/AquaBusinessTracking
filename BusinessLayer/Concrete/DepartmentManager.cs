using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.DepartmentDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : GenericManager<DB_Department, DepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>, IDepartmentService
    {
        public DepartmentManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
