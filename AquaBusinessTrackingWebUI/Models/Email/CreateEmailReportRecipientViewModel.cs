using System.ComponentModel.DataAnnotations;

namespace AquaBusinessTrackingWebUI.Models.Email
{
    public class CreateEmailReportRecipientViewModel
    {

        [Required(ErrorMessage = "Rapor kodu zorunludur.")]
        [StringLength(100)]
        public string ReportCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(320)]
        public string EmailAddress { get; set; } = string.Empty;

    }
}
