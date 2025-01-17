using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Localization;
using MimeKit;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Email;
using School.Application.Base.Shared.Resources;

namespace School.Application.Handlers.Email.Commends
{

    public class SendEmail : IRequest<Result<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
    public class EmailsCommandHandler : IRequestHandler<SendEmail, Result<string>>
    {
        private readonly EmailSettings _emailSettings;
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        public EmailsCommandHandler(EmailSettings emailSettings, IStringLocalizer<ResourcesLocalization> Localizer)
        {
            this._emailSettings = emailSettings;
            this.Localizer = Localizer;

        }
        public async Task<Result<string>> Handle(SendEmail request, CancellationToken cancellationToken)
        {
            try
            {

                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{request.Message}",
                        TextBody = "wellcome ahmed mahdy",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Zakaria Team", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("Mahdy Team", request.Email));
                    message.Subject = request.Subject;
                    var res = await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email

                return Result<string>.Success(request.Email, Localizer[ResourcesLocalizationKeys.EmailSent]);
            }

            catch (Exception ex)
            {

                return Result<string>.Success(request.Email, Localizer[ResourcesLocalizationKeys.EmailFailled] + ex.Message);
            }
        }
    }
}
