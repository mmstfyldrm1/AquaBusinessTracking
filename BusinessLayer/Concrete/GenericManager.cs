using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;

namespace BusinessLayer.Concrete
{
    public class GenericManager<TEntity, TDto, TCreateDto, TUpdateDto> : IGenericService<TDto, TCreateDto, TUpdateDto> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public GenericManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        protected virtual IGenericRepository<TEntity> Repository
            => _uow.Repository<TEntity>();


        public async Task<List<TDto>> GetList()
        {
            var data = await Repository.TGetAll();
            return _mapper.Map<List<TDto>>(data);
        }

        public async Task<TDto> GetById(int id)
        {
            var entity = await Repository.TGetById(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Add(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await Repository.TAdd(entity);
            await _uow.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task Update(TUpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await Repository.TUpdate(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Repository.TGetById(id);
            await Repository.TDelete(entity);
            if (entity == null) return;


            await _uow.SaveChangesAsync();
        }
    }
}
