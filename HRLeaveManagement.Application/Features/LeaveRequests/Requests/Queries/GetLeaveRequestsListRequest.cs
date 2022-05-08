using HRLeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestsListRequest : IRequest<IReadOnlyList<LeaveRequestListDto>>
    {
    }
}
