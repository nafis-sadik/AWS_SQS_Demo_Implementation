using Models;

namespace Subscriber
{
    public class CabinPostHandler: IHandlerBase<Cabin>
    {
        public Task HandleAsync(Cabin message)
        {
            Console.WriteLine(message.ToString());
            Console.WriteLine(message.GetType());
            Console.WriteLine("Successs");
            return Task.CompletedTask;
        }
    }
}
