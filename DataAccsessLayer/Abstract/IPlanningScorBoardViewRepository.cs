using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IPlanningScorBoardViewRepository : IGenericRepository<DB_PlanningScorBoardView>
    {
        public Task<List<DB_PlanningScorBoardView>> GetWithDetails();
    }
}
