namespace PRJ.Utility.OutputData;
public class OutputDTO<T>
{
    public bool Succeeded { get; set; } = true;
    public string Message { get; set; } = null!; 
    public int HttpStatusCode { get; set; } = 200;
    public T? Data { get; set; }
}
