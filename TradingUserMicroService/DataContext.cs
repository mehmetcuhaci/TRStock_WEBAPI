using Microsoft.EntityFrameworkCore;
using TradingUserMicroService.Models;


namespace TradingUserMicroService
{
    public class DataContext : DbContext
    {
        public DbSet<UserRegistrationModel> user_info { get; set; }
        public DbSet<StockModel> trade_stocks { get; set; }

       public DataContext(DbContextOptions<DataContext> options):base(options) {
        } 
    }
}
