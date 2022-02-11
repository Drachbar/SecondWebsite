using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace Website.Models
{
    public class ChatRoomModel
    {
        readonly List<IdentityUser> Users = new();
        public int Id { get; set; }
        public void AddUser(IdentityUser user)
        {
            Users.Add(user);
        }
        public List<IdentityUser> GetAllUsers()
        {
            return Users;
        }
    }
}
