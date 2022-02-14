using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace Website.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        readonly List<int> UserIds = new();

        public void AddUser(int userId)
        {
            UserIds.Add(userId);
        }
        public List<int> GetAllUsers()
        {
            return UserIds;
        }

        public ChatRoom()
        {

        }
    }
}
