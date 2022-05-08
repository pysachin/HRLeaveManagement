using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationsDetailsCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto leaveAllocation { get; set; }
    }
}
