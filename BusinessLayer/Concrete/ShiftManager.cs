using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ShiftDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ShiftManager : GenericManager<DB_Shift, ShiftDto, CreateShiftDto, UpdateShiftDto>, IShiftService
    {
        public ShiftManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
