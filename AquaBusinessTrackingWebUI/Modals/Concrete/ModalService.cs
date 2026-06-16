using AquaBusinessTrackingWebUI.Modals.Abstract;
using AquaBusinessTrackingWebUI.Models;

namespace AquaBusinessTrackingWebUI.Modals.Concrete
{
    public class ModalService<T> : IModalService<T> where T : class, new()
    {
        public ModalViewModel<T> BuildAddModel() =>
        new ModalViewModel<T> { IsEdit = false };

        public ModalViewModel<T> BuildEditModel(T entity) =>
            new ModalViewModel<T> { Entity = entity, IsEdit = true };
    }
}
