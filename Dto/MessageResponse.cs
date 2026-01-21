namespace StudentPartal.Dto;

public class MessageResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string ErrorCode { get; set; }
    public Object Data { get; set; }

    public MessageResponse()
    {
        
    }

    public MessageResponse(Object data, string message, string errorCode, bool isSuccess)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
        this.ErrorCode = errorCode;
        this.Data = data;
    }

    public void GetDataSuccess(Object data)
    {
        IsSuccess = true;
        Data = data;
        Message = "Get Data Success";
        ErrorCode = "200";
    }

    public void SetErrorMessage(string message)
    {
        IsSuccess = false;
        Data = null;
        Message = message;
        ErrorCode = "404";
    }
    public void SetMessageInternalServerError(string message)
    {
        IsSuccess = false;
        Data = null;
        Message = message;
        ErrorCode = "500";
    }
}