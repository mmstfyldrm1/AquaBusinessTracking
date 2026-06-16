namespace AquaBusinessTrackingWebUI.Models
{
    public class ModalViewModel<T> where T : class, new()
    {
        public T Entity { get; set; } = new();
        public bool IsEdit { get; set; }
        public string ModalTitle { get; set; }

        public string FormAction { get; set; }
    }
}
