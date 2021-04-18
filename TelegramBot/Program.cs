using System;
using System.Linq;
using Telegram.Bot;

namespace TelegramBot
{
    /// <summary>
    ///   Open telegram and search for official BotFather
    ///   Choose /newbot
    ///   Choose name of your bot like csharp_messaging_bot
    ///   Replace your own key
    /// </summary>

    class Program
    {
        static TelegramBotClient Bot = new TelegramBotClient("YourOwnKey123456789");

        static void Main(string[] args)
        {
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;

            Console.ReadKey();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            Bot.SendTextMessageAsync(e.Message.Chat.Id, "Welcome to my channel");

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {

                if (e.Message.Text.StartsWith("Hello"))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello " + e.Message.Chat.FirstName + e.Message.Chat.LastName);

                }


                if (e.Message.Text.StartsWith("/count("))
                {
                    string response = "The number of letters in your text are: ";

                    response += e.Message.Text.Split('(')[1].Split(')')[0].Count().ToString();

                    Bot.SendTextMessageAsync(e.Message.Chat.Id, response);
                }
            }
        }
    }
}
