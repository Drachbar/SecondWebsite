using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class UserRoomsModel
    {
        public int UserId { get; set; }

        readonly List<int> chatRoomsId = new();

        public void AddChatRoom(int chatRoomId)
        {
            chatRoomsId.Add(chatRoomId);
        }

        public List<int> GetAllChatRooms()
        {
            return chatRoomsId;
        }
    }
}
