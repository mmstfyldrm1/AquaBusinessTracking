
using BusinessLayer.Abstract.MailService.@abstract;

namespace BusinessLayer.Abstract.MailService.concrete
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public string Render(
            string templateName,
            Dictionary<string, string> parameters)
        {
            var templatePath = Path.Combine(
                AppContext.BaseDirectory,
                "EmailTemplates",
                $"{templateName}.html"
            );

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException(
                    $"Mail şablonu bulunamadı. Aranan tam yol: {templatePath}"
                );
            }

            var html = File.ReadAllText(templatePath);

            foreach (var parameter in parameters)
            {
                html = html.Replace(
                    "{{" + parameter.Key + "}}",
                    System.Net.WebUtility.HtmlEncode(parameter.Value)
                );
            }

            return html;
        }
    }
}
