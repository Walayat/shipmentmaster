namespace PRJ.Service.CommonServices;
public interface ICommonService<T, K, U> where T : class
{
    public OutputDTO<Task<U>> Create(T obj);
    public OutputDTO<Task<U>> Delete(K id);
    public OutputDTO<Task<U>> Get(K id);
    public OutputDTO<Task<U>> GetAll();
    public OutputDTO<Task<U>> Update(T obj);
}
