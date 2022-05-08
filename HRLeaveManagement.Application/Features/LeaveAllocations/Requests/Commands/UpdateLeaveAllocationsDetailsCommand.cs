using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationsDetailsCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto UpdateLeaveAllocation { get; set; }
    }
}
