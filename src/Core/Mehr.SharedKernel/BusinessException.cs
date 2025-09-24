namespace Mehr.SharedKernel;

public class BusinessException : Exception
{
    public Result Result { get; set; }
    public BusinessException(Result result) : base(result.Error.Description)
    {
        Result = result;
    }
}