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
    }
}
