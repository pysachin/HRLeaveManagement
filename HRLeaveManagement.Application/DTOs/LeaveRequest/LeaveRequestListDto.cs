using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequeted { get; set; }
        public bool? Approved { get; set; }
    }
}
