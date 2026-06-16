using AquaBusinessTrackingWebUI.Models;

namespace AquaBusinessTrackingWebUI.Modals.Abstract
{
    public interface IModalService<T> where T : class, new()
    {
        ModalViewModel<T> BuildAddModel();
        ModalViewModel<T> BuildEditModel(T entity);
    }
}
