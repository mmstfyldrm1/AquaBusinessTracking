using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.KazanDtos.KazanDetailDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KazanChemicalsDetailManager : GenericManager<DB_KazanChemicalsDetail, KazanChemicalsDetailDto, CreateKazanChemicalsDetailDto, UpdateKazanChemicalsDetailDto>, IKazanChemicalsDetailService
    {
        public KazanChemicalsDetailManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
