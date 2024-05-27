using SimpleCatBot.Helpers;
using System.Configuration;

class CatBotMain
{
     public static async Task Main()
     {
        List<Task> tasks = new List<Task>();
        ConfigManager manager= new ConfigManager(ConfigurationManager.AppSettings);
        string pageId = manager.GetPageId();
        IEnumerable<string> recipientIds = manager.GetrecipientIds();
        string pageAccessToken = manager.GetpageAccessToken();

        foreach (string recipientId in recipientIds)
        {
            tasks.Add(Task.Run(async () =>
            {
                ChatMessagesHandler handler = new ChatMessagesHandler
                (new MetaApiHandler(recipientId, pageId, pageAccessToken));
                await handler.ListenToChatAndReact();
            }));
        }
        await Task.WhenAll(tasks);
    }
}
