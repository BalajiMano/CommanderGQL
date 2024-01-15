using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
namespace CommanderGQL.Data
{


    public class PlatformDBContext :DbContext
    {
       public PlatformDBContext(DbContextOptions<PlatformDBContext> opt) :base(opt)
       {

       }

       public DbSet<Platform> platforms{set; get;}
    }
}
