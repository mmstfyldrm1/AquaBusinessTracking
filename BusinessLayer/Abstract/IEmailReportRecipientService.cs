using DTOLayer.Dtos.Email;

namespace BusinessLayer.Abstract
{
    public interface IEmailReportRecipientService
    {

        Task<List<string>> GetActiveEmailsByReportCode(string reportCode);

        Task<List<EmailReportRecipientDto>> GetList();

        Task<EmailReportRecipientDto> GetById(int id);

        Task<EmailReportRecipientDto> Add(CreateEmailReportRecipientDto dto);


        Task Update(UpdateEmailReportRecipientDto dto);

        Task Delete(int id);
    }
}
