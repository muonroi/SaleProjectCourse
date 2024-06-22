using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebSaleRepository.Helper;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Models;
using WebSaleRepository.Services.Interfaces;

namespace WebSaleRepository.Services
{
    public class EmailService : BaseRepository, IEmailService
    {
        private readonly SendGridSetting _sendGridSetting;
        public EmailService(IOptions<SendGridSetting> sendGridSetting)
        {
            _sendGridSetting = sendGridSetting.Value;
        }

        public async Task<TResponse<bool>> SendBulkEmailFromExcelFile(IFormFile file)
        {
            List<EmailModel> emailModels = new List<EmailModel>();
            if (file == null || file.Length == 0)
            {
                return await Fail<bool>("File can not null or empty!");
            }
            using (Stream streamData = file.OpenReadStream())
            {
                emailModels = ExcelHelper.FeatchEmailFromExcelFile(streamData);
            }

            SendGridClient sendGridClient = new SendGridClient(_sendGridSetting.ApiKey);
            foreach (EmailModel item in emailModels)
            {
                await Send(sendGridClient, item);
            }
            return await OK(true);
        }

        public async Task<TResponse<bool>> SendEmail(EmailModel emailModel)
        {
            if (emailModel == null)
            {
                return await Fail<bool>("Info mail send not null or empty");
            }
            SendGridClient client = new SendGridClient(_sendGridSetting.ApiKey);
            await Send(client, emailModel);
            return await OK(true);
        }

        private async Task Send(SendGridClient client, EmailModel emailModel)
        {
            EmailAddress sendFrom = new EmailAddress("admin.contact@muonroi.online", "muonroi.online");
            EmailAddress sendTo = new EmailAddress(emailModel.ToEmail);
            SendGridMessage message = MailHelper.CreateSingleEmail(sendFrom, sendTo, emailModel.Subject, emailModel.Content, emailModel.Content);
            _ = await client.SendEmailAsync(message);
        }
    }
}
