﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.ViewModels.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }
    }
}