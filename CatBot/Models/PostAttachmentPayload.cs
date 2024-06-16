namespace SimpleCatBot.Models
{
    public class Attachment
    {
        public string type { get; set; }
        public Payload payload { get; set; }

        public Attachment(string inputUrl)
        {
            type = "image";
            payload = new Payload(inputUrl, false);
        }
    }

    public class Message
    {
        public Attachment attachment { get; set; }

        public Message(string inputUrl)
        {
            attachment = new Attachment(inputUrl); 
        }
    }

    public class Payload
    {
        public string url { get; set; }
        public bool is_reusable { get; set; }

        public Payload(string inputUrl,bool inputis_reusable)
        {
            url=inputUrl;
            is_reusable=inputis_reusable;         
        }
    }

    public class Recipient
    {
        public string id { get; set; }

        public Recipient(string inputid)
        {
            id = inputid;           
        }
    }

    public class PostAttachmentPayload
    {
        public Recipient recipient { get; set; }
        public Message message { get; set; }
        public string access_token { get; set; }

        public PostAttachmentPayload(string recipientId,string catsUrl,string pageAccessToken)
        {
            recipient=new Recipient(recipientId);
            message=new Message(catsUrl);
            access_token=pageAccessToken;
        }
    }

}
