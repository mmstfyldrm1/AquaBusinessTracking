using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IPapperMachineChemicalRepository : IGenericRepository<DB_PapperMachineChemical>
    {
        public Task<List<DB_PapperMachineChemical>> GetWithDetails();

        public Task<List<DB_PapperMachineChemical>> GetPreviousDay();
    }
}
