using DotnetOrangeSms;
using DotnetOrangeSms.Extensions;
using System;

namespace ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var smsClient = SmsClient.Authenticate("Basic QmYwc0ZCOVdWUVJXZmR0Ynl6M0daRWY3RFdDajVyNkw6TjJyVEI2M0ZrVmU5NFJuMQ==").Result;
            var response = smsClient.SendSms("Test", "243808790260", "243998954037", "Mandal").Result;
            if (response.IsSuccess)
                Console.WriteLine(response.Value);
            else
                Console.WriteLine(response.Error);
        }
    }
}
