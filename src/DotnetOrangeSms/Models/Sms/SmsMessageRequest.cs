using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetOrangeSms.Models
{
    public class SmsMessageRequest
    {
        [JsonProperty("address")]
        public string Recipients { get; set; }
        
        [JsonProperty("outboundSMSTextMessage")]
        public SmsTextMessage SmsTextMessage { get; set; }
    }
}
