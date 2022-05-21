using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList
{
    public class GetAPTListQuery : IRequest<APTListVm>
    {
        public Guid UserId { get; set; }
    }
}
