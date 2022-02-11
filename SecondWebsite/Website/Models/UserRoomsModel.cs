using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class UserRoomsModel
    {
        public IdentityUser? User { get; set; }

        readonly List<ChatRoomModel> chatRooms = new();

        public void AddChatRoom(ChatRoomModel chatRoom)
        {
            chatRooms.Add(chatRoom);
        }

        public List<ChatRoomModel> GetAllChatRooms()
        {
            return chatRooms;
        }
    }
}
