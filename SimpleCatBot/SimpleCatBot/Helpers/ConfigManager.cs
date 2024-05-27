using System.Collections.Specialized;


namespace SimpleCatBot.Helpers
{
    internal class ConfigManager
    {
        private NameValueCollection appSettings;

        public ConfigManager(NameValueCollection appSettings)
        {
            this.appSettings = appSettings;
        }

        internal string GetpageAccessToken()
        {
            string? token = appSettings["pageAccessToken"];
            ArgumentNullException.ThrowIfNull(token);
            return token;
        }

        internal string GetPageId()
        {
            string? retVal = appSettings["pageId"];
            ArgumentNullException.ThrowIfNull(retVal);
            return retVal;
        }

        internal IEnumerable<string> GetrecipientIds()
        {
            string? recipients = appSettings["recipientIds"];
            ArgumentNullException.ThrowIfNull(recipients);
            return recipients.Split(",");
        }
    }
}
