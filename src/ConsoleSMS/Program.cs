//// See https://aka.ms/new-console-template for more information
//using System.Net.Mail;

//Console.WriteLine("Hello, World!");


using DotnetOrangeSms;
using DotnetOrangeSms.Extensions;
using DotnetOrangeSms.Models;

public class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            //Authentication
           // var smsClient = await SmsClient.Authenticate("{{authorization_header}}");
            var smsClient = await SmsClient.Authenticate("Basic N1ptZFdTY0NUM1VCZkg1SFEzZW0yNWdna3h0WElBbDA6a2s5NHpRZ2xZcVdCOGZiMQ==");
            Console.WriteLine("Account authenticated");
            PrintSeparator();
            //Send an sms
            await SendingSms(smsClient);
            PrintSeparator();
            //View Balance
            await VerifyingBalance(smsClient);
            PrintSeparator();
            //View SMS Usage statistics
            await GettingStatistics(smsClient);
            PrintSeparator();
            //View purchase history
            await GetPurchaseHistory(smsClient);
            PrintSeparator();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception:{ex.Message}");
        }



    }
    private static async Task GetPurchaseHistory(SmsClient smsClient)
    {
        var pruchaseHistoryResponse = await smsClient.GetPurchaseHistory();
        if (pruchaseHistoryResponse.IsSuccess)
            Console.WriteLine($"Stats: {pruchaseHistoryResponse.Value}");
        else
            Console.WriteLine($"Failed to fecth purchase order:{pruchaseHistoryResponse.Error}");
    }

    private static async Task GettingStatistics(SmsClient smsClient)
    {
        var statisticsResponse = await smsClient.GetStatistics();
        if (statisticsResponse.IsSuccess)
            Console.WriteLine($"Stats: {statisticsResponse.Value}");
        else
            Console.WriteLine($"Failed to fecth statistics:{statisticsResponse.Error}");
    }

    private static async Task VerifyingBalance(SmsClient smsClient)
    {
        var balanceResponse = await smsClient.VueBalance();
        if (balanceResponse.IsSuccess)
            Console.WriteLine($"Balance: {balanceResponse.Value}");
        else
            Console.WriteLine($"Failed to fecth balance:{balanceResponse.Error}");
    }

    private static async Task SendingSms(SmsClient smsClient)
    {
        var response = await smsClient.SendSms("Test C# pour MAUI", "2250000", "2250709768110", "RESAFIG");
        if (response.IsSuccess)
            Console.WriteLine($"Sms sent: {response.Value}");
        else
            Console.WriteLine($"Sending sms failed:{response.Error}");
    }

    private static void PrintSeparator()
    {
        Console.WriteLine($"{Environment.NewLine}********************************************************************************************{Environment.NewLine}");
    }

}