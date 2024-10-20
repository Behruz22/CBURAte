using Microsoft.EntityFrameworkCore;

namespace CBURate.Data
{
    public class CBUContext : DbContext
    {
        public DbSet<IncomingModel> models { get; set; }

        public CBUContext(DbContextOptions<CBUContext> dbContextOptionsBuilder) : base(dbContextOptionsBuilder) { }

    }
}
