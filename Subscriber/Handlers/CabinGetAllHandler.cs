using Models;

namespace Subscriber
{
    public class CabinGetAllHandler: IHandlerBase<CabinFilters>
    {
        public Task HandleAsync(CabinFilters message)
        {
            Console.WriteLine(message.ToString());
            Console.WriteLine(message.GetType());
            Console.WriteLine("Successs");
            return Task.CompletedTask;
        }
    }
}
