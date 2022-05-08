using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestDto leaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto changeLeaveRequestApproval { get; set; }
    }
}
