using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.MessageDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : GenericManager<DB_Message, MessageDto, CreateMessageDto, UpdateMessageDto>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IUnitOfWork uow, IMapper mapper, IMessageRepository messageRepository)
            : base(uow, mapper)
        {
            _messageRepository = messageRepository;
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _messageRepository.GetUnreadCountAsync(userId);

        }

        public async Task MarkAsReadAsync(int senderId, int receiverId)
        {
            await _messageRepository.MarkAsReadAsync(senderId, receiverId);
        }
    }
}
