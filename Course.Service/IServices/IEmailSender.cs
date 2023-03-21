

using Microsoft.AspNetCore.Http;

namespace Course.Service.IServices {
    public interface IEmailSender {
        Task SendEmailAsync(string mailto, string subject, string body);
    }
}
