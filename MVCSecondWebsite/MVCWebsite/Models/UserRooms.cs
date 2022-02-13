using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class UserRooms
    {
        [Key]
        public int UserId { get; set; }

        List<int> chatRoomsId = new();

        public void AddChatRoom(int chatRoomId)
        {
            chatRoomsId.Add(chatRoomId);
        }

        public List<int> GetAllChatRooms()
        {
            return chatRoomsId;
        }

        public UserRooms()
        {

        }
    }
}
