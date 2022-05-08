﻿using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
