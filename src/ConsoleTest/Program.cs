using DotnetOrangeSms;
using DotnetOrangeSms.Extensions;
using System;

namespace ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var smsClient = SmsClient.Authenticate("Token").Result;
            var response = smsClient.SendSms("Test", "243808790260", "243998954037", "Mandal").Result;
            if (response.IsSuccess)
                Console.WriteLine(response.Value);
            else
                Console.WriteLine(response.Error);
        }
    }
}
