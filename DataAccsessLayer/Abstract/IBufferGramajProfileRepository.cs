using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBufferGramajProfileRepository : IGenericRepository<DB_BufferGramajProfile>
    {
        public Task<List<DB_BufferGramajProfile>> GetWithDetails();
    }
}
