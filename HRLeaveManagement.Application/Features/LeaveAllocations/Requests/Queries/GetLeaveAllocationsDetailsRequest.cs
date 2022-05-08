using HRLeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    class GetLeaveAllocationsDetailsRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
