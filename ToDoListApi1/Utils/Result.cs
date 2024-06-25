namespace ToDoListApi1.Utils
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string? Error;
        public bool IsSuccess { get; set; }

        public static Result<T> Success(T Data)
        {
            return new Result<T>
            {
                Data = Data,
                IsSuccess = true
            };
        }

        public static Result<T> Fail(string error)
        {
            return new Result<T>
            {
                Error = error,
                IsSuccess = false
            };
        }
    }
}
