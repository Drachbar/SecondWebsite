using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class ChatMessagesModel
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }
        
        public string? ChatMessage { get; set; }
        
        public DateTime DateTime { get; set; }

        public string? UserName { get; set; }

        public int UserId { get; set; }

        public ChatMessagesModel()
        {

        }
    }
}
