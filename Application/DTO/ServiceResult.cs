
namespace Application.DTO
{
    public class ServiceResult<T> where T : class
    { 
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }


        public static ServiceResult<T> SucessResult(T? data, string? message)
        {
            return new ServiceResult<T>()
            {
                Success = true,
                Data = data,
                Message = message
            };
        }
        public static ServiceResult<T> FailResult( string? message)
        {
            return new ServiceResult<T>()
            {
                Success = false,
                Message = message
            };
        }
    }
}
