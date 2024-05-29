using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TradingUserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public StockController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var entities=await _dataContext.trade_stocks.ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetStockByCode(string code)
        {
            var stock=await _dataContext.trade_stocks.FirstOrDefaultAsync(s=> s.code==code);
            if (stock==null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

    }
}
