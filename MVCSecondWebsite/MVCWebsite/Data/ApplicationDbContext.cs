using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace MVCWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ChatMessage>? ChatMessagesModel { get; set; }
        public DbSet<Website.Models.ChatRoom> ChatRoom { get; set; }
        public DbSet<Website.Models.UserRooms> UserRooms { get; set; }
    }
}