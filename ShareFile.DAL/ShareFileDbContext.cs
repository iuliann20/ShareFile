using Microsoft.EntityFrameworkCore;
using ShareFile.DAL.Entities;

namespace ShareFile.DAL
{
    public class ShareFileDbContext : DbContext
    {
        public ShareFileDbContext(DbContextOptions<ShareFileDbContext> options) : base(options)
        {
        }

        public DbSet<SharedFile> Files { get; set; }
        public DbSet<SharedFileUser> Users { get; set; }
        public DbSet<Token> AccessTokens { get; set; }


    }
}
