using System.Net;

namespace PRJ.Utility.OutputData;

public static class ResponseCode
{
    public const int CREATE = 201;
    public const int UPDATE = 201;
    public const int DELETE = 200;
    public const int GET = 200;
    public const int GET_ALL = 200;
    public const int FOUND = 200;
    public const int NOT_FOUND = 400; 
}
public static class ResponseMessage
{
    public const string CREATE = "Record creates successfully.";
    public const string UPDATE = "Record updates successfully.";
    public const string DELETE = "Record deletes successfully.";
    public const string GET = "Record gets successfully.";
    public const string GET_ALL = "Records get successfully.";
    public const string FOUND = "Record found successfully.";
    public const string NOT_FOUND = "Record does not found.";
    public const string BAD_REQUEST = "Something went wrong.";
}

public enum ResponseType
{
    CREATE,
    UPDATE,
    DELETE,
    GET,
    GET_ALL,
    FOUND,
    NOT_FOUND,

    USER_CREATE,
    USER_UPDATE,
    USER_DELETE,
    USER_EXIST,
    USER_NOT_FOUND,
    GET_USER,
    GET_ALL_USERS,
    INVALID_CREDENTIALS,
    SUCCESSFULLY_LOGIN,
    EMAIL_EXIST,
    SUCCESSFULLY_REGISTER,
}




