using Microsoft.EntityFrameworkCore;
using TransactionSystemAPI.Model;

namespace TransactionSystemAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<TransactionModel> transactions { get; set; }
    }
}
