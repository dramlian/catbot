using System.Text.RegularExpressions;


namespace SimpleCatBot.Helpers
{
    internal class ChatMessagesHandler
    {
        private MetaApiHandler _handler {  get; set; }

        public ChatMessagesHandler(MetaApiHandler handler)
        {
            this._handler = handler;
        }

        public async Task ListenToChatAndReact()
        {
            while (true)
            {
                var newestMessage = await _handler.GetMessages();
                if (newestMessage.message != null && newestMessage.message.ToLower().Contains("maciatko"))
                {
                    await SendCatImageIterationTimes(DecideNumberOfIterations(newestMessage.message));
                }
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }

        public int DecideNumberOfIterations(string message)
        {
            string pattern = @"(?i)maciatko\s*(\d+)";
            Regex regex = new Regex(pattern);
            var match = regex.Match(message);
            if (match.Success)
            {
                int number = Int32.Parse(match.Groups[1].Value);
                if (number > 30)
                {
                    return 30;
                }
                return number;
            }
            return 1;
        }

        public async Task SendCatImageIterationTimes(int numberOfMessages)
        {
            List<Task> tasks = new List<Task>();
            for(int i = 0; i < numberOfMessages; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await _handler.SendCatImage();
                }));
            }
            await Task.WhenAll(tasks);
        }
    }
}
