using BusinessLayer.Abstract;
using DTOLayer.Dtos.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AquaBusinessTrackingWebApi.Services
{
    [Authorize]
    public class MessageHub : Hub
    {
        private readonly IMessageService _messageService;

        public MessageHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessage(CreateMessageDto dto)
        {

            var savedMessage = await _messageService.Add(dto);


            await Clients.User(dto.ReceiverId.ToString())
                .SendAsync("ReceiveMessage", savedMessage);


            await Clients.Caller
                .SendAsync("ReceiveMessage", savedMessage);
        }
    }
}

