﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Exceptions.Models
{
    class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}