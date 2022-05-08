using HRLeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
