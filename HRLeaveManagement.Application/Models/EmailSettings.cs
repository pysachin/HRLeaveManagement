﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}