using SimpleCatBot.Helpers;

class CatBotMain
{
    private static string pageId= "gv2Je8O+y9sBEMZk7GqyoxrJ95FelTcau68rsVkz+oI=";
    private static string recipientId = "gTTEVw/gUf9FdBLXPU4ZkQq9BnqwfCB1WJjXRchbK5Q=";
    private static string pageAccessToken = "Pa22/Yra8dCZxRDiUrbLoxtbunt0/yq2j6lKI4byVoLNVQ0MQbbtnNW5U0XGzqvmnAWTW6uugwUMDDyrN1JY3zi0gzIbG2J4QAgCpcj3xoXYfrKR7Gq6FsSAAMtFcc6eN2KXZouZYhMqqZZ6fR84xLM6k/p7iYK6E3ONE2eDaQuTTbBxTYvQtvpVwEdDnOxpVfr6AoHJxb9pUtAE4bfNzACxUSwqFrDch1iX14Qg1fWSe6ziJDItAhAh/3/MPgLzYsaBmb6abbTcfKZdYV2pDg==";

     public static async Task Main()
     {
        string key = ""; 

        pageId = AESE.Decrypt(pageId, key);
        recipientId = AESE.Decrypt(recipientId, key);
        pageAccessToken = AESE.Decrypt(pageAccessToken, key);

        while (true)
        {
            MetaApiHandler handler = new MetaApiHandler(recipientId, pageId, pageAccessToken);
            var newestMessage = await handler.GetMessages(recipientId);
            if (newestMessage.message != null && newestMessage.message.ToLower().Contains("maciatko"))
            {
                await handler.SendCatImage();
            }
            Thread.Sleep(TimeSpan.FromSeconds(30));
            handler.Dispose();
        }
    }
}
