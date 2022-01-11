using Invoice.Application.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Options
{
    public class ProductApiOptions
    {
        public string BaseUrl { get; set; } = "url";
    }
}
