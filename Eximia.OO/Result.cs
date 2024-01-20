namespace Eximia.OO
{
    public interface IResult
    {
        string Error { get; }
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public readonly struct Result : IResult
    {
        public Result(string error, bool isFailure)
        {
            Error = error;
            IsFailure = isFailure;
        }

        public string Error { get; }
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public static Result Success()
            => new Result(string.Empty, false);

        public static Result Failure(string error)
            => new Result(error, true);
    }

    public readonly struct Result<T> : IResult
    {
        private Result(string error, bool isFailure, T value)
        {
            Error = error;
            IsFailure = isFailure;
            Value = value;
        }

        public string Error { get; }
        public bool IsFailure { get; }
        public T Value { get; }
        public bool IsSuccess => !IsFailure;

        public static Result<T> Failure(string error)
            => new Result<T>(error, true, default!);

        public static implicit operator Result<T>(T value)
            => new Result<T>(string.Empty, false, value);

        public static implicit operator Result<T>(Result result)
            => new Result<T>(result.Error, true, default!);
    }
}
