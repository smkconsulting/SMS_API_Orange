using DotnetOrangeSms.Models;
using System.Net;
using System.Threading.Tasks;

namespace DotnetOrangeSms.Extensions
{
    public static class SmsExtensions
    {
        public static async Task<Result<string>> SendSms(this SmsClient smsClient, string message, string from, string to,string senderName = "")
        {
            var sms = new SendSmsModel
            {
                Sender = $"tel:+{from}",
                SenderName = senderName,
                SmsMessageRequest = new SmsMessageRequest
                {
                    Recipients = $"tel:+{to}",
                    SmsTextMessage = new SmsTextMessage
                    {
                        Message = message
                    }
                }
            };
            var response = await smsClient.PostAsync(sms, $"smsmessaging/v1/outbound/{from}/requests");
            if(response.code == HttpStatusCode.Created)
                return new Result<string>(true, string.Empty, response.result);
            return new Result<string>(false, $"error_code: {(int)response.code}, body: {response.result}", null);

        }
    }
}
