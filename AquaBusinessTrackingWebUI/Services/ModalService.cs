using AquaBusinessTrackingWebUI.Models;

namespace AquaBusinessTrackingWebUI.Services
{
    public class ModalService
    {
        public ModalViewModel<T> BuildAddModel<T>() where T : class, new()
        => new ModalViewModel<T> { IsEdit = false };

        public ModalViewModel<T> BuildEditModel<T>(T entity) where T : class, new()
            => new ModalViewModel<T> { Entity = entity, IsEdit = true };
    }
}
