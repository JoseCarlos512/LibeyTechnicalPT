namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Exceptions;

public class CustomValidationException: Exception   
{
    public string ErrorCode { get; }
    public string UserFriendlyMessage { get; }

    public CustomValidationException(string errorCode, string userFriendlyMessage)
        : base(userFriendlyMessage)
    {
        ErrorCode = errorCode;
        UserFriendlyMessage = userFriendlyMessage;
    }
}