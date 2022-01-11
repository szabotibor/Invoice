using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Dto
{
    public class WeeklySaleReportItemDto
    {
        public int StoreId { get; set; }
        public IList<DailySaleDto> DailySales { get; set; } = new List<DailySaleDto>();
        public decimal Total { get; set; }


    }
}
