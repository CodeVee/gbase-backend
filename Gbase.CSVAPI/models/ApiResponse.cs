﻿namespace Gbase.CSVAPI.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
