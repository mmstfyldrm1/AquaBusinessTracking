using DTOLayer.Dtos.MessageDtos;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<MessageDto, CreateMessageDto, UpdateMessageDto>
    {
        Task<int> GetUnreadCountAsync(int userId);

        Task MarkAsReadAsync(int senderId, int receiverId);
    }
}
