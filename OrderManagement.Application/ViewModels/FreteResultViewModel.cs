using System.Net;

namespace OrderManagement.Application.ViewModels
{
    public class FreteResultViewModel<T>
    {
        public FreteResultViewModel(T data, HttpStatusCode status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; } = null!;
    }
}
