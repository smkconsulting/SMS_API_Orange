using Newtonsoft.Json;

namespace DotnetOrangeSms.Models
{
    class SendSmsModel
    {
        [JsonProperty("outboundSMSMessageRequest")]
        public SmsMessageRequest SmsMessageRequest { get; set; } 
        [JsonProperty("senderAddress")]
        public string Sender { get; set; }
        [JsonProperty("senderName")]
        public string SenderName { get; set; }
    }
}
