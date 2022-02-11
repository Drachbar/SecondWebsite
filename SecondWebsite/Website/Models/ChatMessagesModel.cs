using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class ChatMessagesModel
    {
        public int ChatRoomId { get; set; }
        public string? ChatMessage { get; set; }
        public DateTime DateTime { get; set; }
        public IdentityUser? User { get; set; }
    }
}
