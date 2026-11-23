namespace BusinessLayer.Abstract.MailService.@abstract
{
    public interface IEmailTemplateService
    {
        string Render(string templateName, Dictionary<string, string> parameters);
    }
}
