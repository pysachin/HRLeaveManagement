using HRLeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeListRequest : IRequest<IReadOnlyList<LeaveTypeDto>>
    {

    }
}
