
namespace SimpleCatBot.Helpers
{
    public class CatBotHAndler
    {
        private readonly ILogger<CatBotHAndler> _logger;
        private bool _isRunning;

        private readonly string _pageId;

        private readonly IEnumerable<string> _recipientIds;

        private readonly string _pageAccessToken;

        public CatBotHAndler(ILogger<CatBotHAndler> logger)
        {
            _logger = logger;
            _isRunning = true;
            _pageId = "1014469071960953";
            _recipientIds = new List<string>() { "7504028356359802", "8230986756915731" };
            _pageAccessToken = "";
        }

        public void StopBot()
        {
            _isRunning = false;
        }

        public async Task StartBot()
        {
            _isRunning = true;

            while (true)
            {
                if (!_isRunning)
                {
                    break;
                }

                _logger.LogInformation("Checking for messages and sending cat image at: {time}", DateTimeOffset.Now);
                List<Task> tasks = new List<Task>();
                foreach (string recipientId in _recipientIds)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        ChatMessagesHandler handler = new ChatMessagesHandler
                        (new MetaApiHandler(recipientId, _pageId, _pageAccessToken));
                        await handler.ListenToChatAndReact();
                    }));
                }
                await Task.WhenAll(tasks);

            }

            _logger.LogInformation("CatBot service stopped.");
        }
    }
}