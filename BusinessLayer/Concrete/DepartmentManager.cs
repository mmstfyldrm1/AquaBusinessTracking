using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.DepartmentDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : GenericManager<DB_Department, DepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>, IDepartmentService
    {
        public DepartmentManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
