using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PlcMachineManager : GenericManager<DB_PlcMachine, PlcMachineDto, CreatePlcMachineDto, UpdatePlcMachineDto>, IPlcMachineService
    {
        public PlcMachineManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
