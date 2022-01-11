using Store.Application.Dto;
using Store.Application.Messaging.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Messaging.Commands
{
    public class UpdateMyStoreCommand : CommandBase<StoreDto>
    {
        public UpdateMyStoreCommand(StoreDto data) : base(data)
        {
        }
    }
}
