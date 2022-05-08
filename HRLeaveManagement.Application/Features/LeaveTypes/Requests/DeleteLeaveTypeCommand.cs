using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
