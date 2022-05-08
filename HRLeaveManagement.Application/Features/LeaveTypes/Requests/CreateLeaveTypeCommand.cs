using HRLeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
