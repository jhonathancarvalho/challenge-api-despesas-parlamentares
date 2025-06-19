using DespesasParlamentares.API.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DespesasParlamentares.API.Models.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public Response(bool success, int status, T? data = default, string? message = null)
        {
            Success = success;
            Status = status;
            Data = data;
            Message = message;
        }
    }
}
