using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ShiftDtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ShiftManager : GenericManager<DB_Shift, ShiftDto, CreateShiftDto, UpdateShiftDto>, IShiftService
    {
        public ShiftManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
