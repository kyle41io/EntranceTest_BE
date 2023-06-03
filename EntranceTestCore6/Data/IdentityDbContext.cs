using Microsoft.EntityFrameworkCore;

namespace EntranceTestCore6.Data
{
    public class IdentityDbContext
    {
        private DbContextOptions<AppDbContext> options;

        public IdentityDbContext(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }
    }
}
