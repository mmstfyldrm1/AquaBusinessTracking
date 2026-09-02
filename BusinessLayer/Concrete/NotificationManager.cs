using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.NotificationDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationRepository _dal;
        private readonly IMapper _mapper;

        public NotificationManager(INotificationRepository dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> GetUnreadAsync(int appUserId)
        {
            var list = await _dal.GetUnreadAsync(appUserId);
            return _mapper.Map<List<NotificationDto>>(list);
        }

        public async Task MarkAsReadAsync(int id) => await _dal.MarkAsReadAsync(id);

        public async Task<NotificationDto> SendAsync(CreateNotificationDto dto)
        {
            var entity = _mapper.Map<DB_Notification>(dto);
            var saved = await _dal.AddAsync(entity);
            return _mapper.Map<NotificationDto>(saved);
        }
    }
}
