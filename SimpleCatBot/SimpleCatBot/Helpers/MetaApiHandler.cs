namespace SimpleCatBot.Helpers
{
    using SimpleCatBot.Models;
    using System;

    public class MetaApiHandler : ApiHandler
    {
        private readonly string _recipientId;
        private readonly string _pageId;
        private readonly string _pageAccessToken;
        private const string _metaUrl = "https://graph.facebook.com/v19.0";
        private const string _catsUrl = "https://cataas.com/cat";

        public MetaApiHandler(string recipientId, string pageId, string pageAccessToken) : base()
        {
            _recipientId = recipientId;
            _pageId = pageId;
            _pageAccessToken = pageAccessToken;
        }

        public async Task<MessageData> GetMessages(string recipientTargetId)
        {
            Data? recipientData = (await GetAsync<CurrentMetaChats>($"{_metaUrl}/{_pageId}/" +
            "conversations?fields=participants,messages{id,message}" +
            $"&access_token={_pageAccessToken}"))?.data?.Where
            (x=> x?.participants?.data!=null
            && x.participants.data.Any(y=>y.id==recipientTargetId))
            .FirstOrDefault();

            ArgumentNullException.ThrowIfNull(recipientData?.messages?.data);
            return recipientData.messages.data.First();
        }

        public async Task<string> SendCatImage()
        {
            string postUrl = $"{_metaUrl}/{_pageId}/messages";
            PostAttachmentPayload payload=new PostAttachmentPayload(_recipientId,
            $"{_catsUrl}?random={Guid.NewGuid()}", _pageAccessToken);

            await PostAsync<PostAttachmentPayload,ResponseAtrachmentMsg>(postUrl,payload);
            return postUrl;
        }
    }

}
