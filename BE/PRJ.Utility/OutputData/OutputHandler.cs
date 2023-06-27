using System.Net;
namespace PRJ.Utility.OutputData;
public static class OutputHandler<T>
{
    public static OutputDTO<T> Handler(int responseCode, T dto)
    {
        var obj = new OutputDTO<T>()
        {
            Data = dto,
        };

        switch (responseCode)
        {
            case (int) ResponseType.CREATE:
                obj.Succeeded = true;
                obj.HttpStatusCode = ResponseCode.CREATE;
                obj.Message = ResponseMessage.CREATE;
                break;

            case (int) ResponseType.UPDATE:
                obj.HttpStatusCode = ResponseCode.UPDATE;
                obj.Message = ResponseMessage.UPDATE;
                break;

            case (int) ResponseType.DELETE:
                obj.HttpStatusCode = ResponseCode.DELETE;
                obj.Message = ResponseMessage.DELETE;
                break;

            case (int) ResponseType.GET:
                obj.HttpStatusCode = ResponseCode.GET;
                obj.Message = ResponseMessage.GET;
                break;

            case (int) ResponseType.GET_ALL:
                obj.HttpStatusCode = ResponseCode.GET_ALL;
                obj.Message = ResponseMessage.GET_ALL;
                break;

            case (int) ResponseType.FOUND:
                obj.HttpStatusCode = ResponseCode.FOUND;
                obj.Message = ResponseMessage.FOUND;
                break;

            case (int) ResponseType.NOT_FOUND:
                obj.Succeeded = false;
                obj.HttpStatusCode = ResponseCode.NOT_FOUND;
                obj.Message = ResponseMessage.NOT_FOUND;
                break;
        }

        return obj;
    }
}
