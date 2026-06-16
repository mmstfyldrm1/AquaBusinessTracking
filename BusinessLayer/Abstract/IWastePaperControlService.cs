using DTOLayer.Dtos.WastePaperControlDtos;

namespace BusinessLayer.Abstract
{
    public interface IWastePaperControlService : IGenericService<WastePaperControlDto, CreateWastePaperControlDto, UpdateWastePaperControlDto>
    {
        public Task<List<WastePaperControlDto>> GetWithDetails();

        public Task<List<WastePaperControlDto>> GetPreviousDay();



    }
}
