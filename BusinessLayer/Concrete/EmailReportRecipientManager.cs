using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.Email;
using EntityLayer.Concrete;
using System.Net.Mail;

namespace BusinessLayer.Concrete
{
    public class EmailReportRecipientManager : IEmailReportRecipientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailReportRecipientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<string>> GetActiveEmailsByReportCode(string reportCode)
        {
            if (string.IsNullOrWhiteSpace(reportCode))
                throw new ArgumentException("Rapor kodu boş olamaz.");

            var recipients = await _unitOfWork
                .Repository<DB_EmailReportRecipient>()
                .TGetAll(x =>
                    x.ReportCode == reportCode &&
                    x.IsActive &&
                    x.InUse == 1 &&
                    x.DeleteDate == null);

            return recipients
                .Select(x => x.EmailAddress)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public async Task<List<EmailReportRecipientDto>> GetList()
        {
            var recipients = await _unitOfWork
                .Repository<DB_EmailReportRecipient>()
                .TGetAll(x => x.DeleteDate == null);

            return recipients.Select(x => new EmailReportRecipientDto
            {
                RecId = x.RecId,
                ReportCode = x.ReportCode,
                EmailAddress = x.EmailAddress,
                IsActive = x.IsActive
            }).ToList();
        }

        public async Task<EmailReportRecipientDto> GetById(int id)
        {
            var entity = await _unitOfWork
                .Repository<DB_EmailReportRecipient>()
                .TGetById(id);

            if (entity == null || entity.DeleteDate != null)
                throw new KeyNotFoundException("E-posta alıcısı bulunamadı.");

            return new EmailReportRecipientDto
            {
                RecId = entity.RecId,
                ReportCode = entity.ReportCode,
                EmailAddress = entity.EmailAddress,
                IsActive = entity.IsActive
            };
        }

        public async Task<EmailReportRecipientDto> Add(
            CreateEmailReportRecipientDto dto)
        {
            ValidateRecipient(dto.ReportCode, dto.EmailAddress);

            var reportCode = dto.ReportCode.Trim().ToUpperInvariant();
            var email = dto.EmailAddress.Trim();

            var existing = await _unitOfWork
                .Repository<DB_EmailReportRecipient>()
                .TGetAll(x =>
                    x.ReportCode == reportCode &&
                    x.EmailAddress == email &&
                    x.DeleteDate == null);

            if (existing.Any())
                throw new InvalidOperationException(
                    "Bu rapor için e-posta adresi zaten kayıtlı.");

            var entity = new DB_EmailReportRecipient
            {
                ReportCode = reportCode,
                EmailAddress = email,
                IsActive = true,
                InUse = 1,
                InsertDate = DateTime.Now
            };

            await _unitOfWork.Repository<DB_EmailReportRecipient>()
                .TAdd(entity);

            await _unitOfWork.SaveChangesAsync();

            return new EmailReportRecipientDto
            {
                RecId = entity.RecId,
                ReportCode = entity.ReportCode,
                EmailAddress = entity.EmailAddress,
                IsActive = entity.IsActive
            };
        }

        public async Task Update(UpdateEmailReportRecipientDto dto)
        {
            ValidateRecipient(dto.ReportCode, dto.EmailAddress);

            var repository = _unitOfWork
                .Repository<DB_EmailReportRecipient>();

            var entity = await repository.TGetById(dto.RecId);

            if (entity == null || entity.DeleteDate != null)
                throw new KeyNotFoundException("E-posta alıcısı bulunamadı.");

            var reportCode = dto.ReportCode.Trim().ToUpperInvariant();
            var email = dto.EmailAddress.Trim();

            var existing = await repository.TGetAll(x =>
                x.RecId != dto.RecId &&
                x.ReportCode == reportCode &&
                x.EmailAddress == email &&
                x.DeleteDate == null);

            if (existing.Any())
                throw new InvalidOperationException(
                    "Bu rapor için e-posta adresi zaten kayıtlı.");

            entity.ReportCode = reportCode;
            entity.EmailAddress = email;
            entity.IsActive = dto.IsActive;
            entity.InUse = dto.IsActive ? (short)1 : (short)0;
            entity.UpdateDate = DateTime.Now;

            await repository.TUpdate(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var repository = _unitOfWork
                .Repository<DB_EmailReportRecipient>();

            var entity = await repository.TGetById(id);

            if (entity == null || entity.DeleteDate != null)
                throw new KeyNotFoundException("E-posta alıcısı bulunamadı.");

            // Fiziksel silme yerine soft delete
            entity.IsActive = false;
            entity.InUse = 0;
            entity.DeleteDate = DateTime.Now;

            await repository.TUpdate(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        private static void ValidateRecipient(string reportCode, string email)
        {
            if (string.IsNullOrWhiteSpace(reportCode))
                throw new ArgumentException("Rapor kodu boş olamaz.");

            if (reportCode.Trim().Length > 100)
                throw new ArgumentException("Rapor kodu en fazla 100 karakter olabilir.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("E-posta adresi boş olamaz.");

            if (email.Trim().Length > 320 ||
                !MailAddress.TryCreate(email.Trim(), out _))
                throw new ArgumentException("Geçerli bir e-posta adresi giriniz.");
        }
    }
}