using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class UserChatRoom
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ChatRoomId { get; set; }

        public UserChatRoom()
        {

        }
    }
}
