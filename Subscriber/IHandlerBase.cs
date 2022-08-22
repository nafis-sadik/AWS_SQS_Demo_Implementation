namespace Subscriber
{
    public interface IHandlerBase<T> where T : class
    {
        public Task HandleAsync(T message);
    }
}
