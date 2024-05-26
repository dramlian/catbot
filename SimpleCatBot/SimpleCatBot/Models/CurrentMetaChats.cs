namespace SimpleCatBot.Models
{
    public class Data
    {
        public Participants? participants { get; set; }
        public Messages? messages { get; set; }
    }

    public class Messages
    {
        public List<MessageData>? data { get; set; }
    }

    public class MessageData
    {
        public string? id { get; set; }
        public string? message { get; set; }
    }
    public class Participants
    {
        public List<ParticipantData>? data { get; set; }
    }

    public class ParticipantData
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
    }

    public class CurrentMetaChats
    {
        public List<Data>? data { get; set; }
    }

}
