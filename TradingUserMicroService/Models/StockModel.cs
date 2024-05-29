using System.ComponentModel.DataAnnotations;

namespace TradingUserMicroService.Models
{
    public class StockModel
    {
        [Key]
        public string code { get; set; }
        public string stockname { get; set; }
        public decimal lastprice { get; set; }
        public decimal volume { get; set; }
    }
}
