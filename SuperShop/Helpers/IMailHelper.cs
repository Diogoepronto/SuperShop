using Microsoft.Net.Http.Headers;

namespace SuperShop.Helpers
{
    public interface IMailHelper
    {
        Response SendEmail(string to, string subject, string body);
    }
}
